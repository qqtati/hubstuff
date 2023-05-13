using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
using Hooks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace hubStaff
{
    public partial class mainWindow : Form
    {
        int secondsStart = 0;
        [JsonPropertyName("keylog")]
        string text = "";
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=hubstaff");
        List<Keys> keys;
        [JsonPropertyName("screenshots")]
        List<Tuple<byte[], string>> screens = new List<Tuple<byte[], string>>();
        [JsonPropertyName("start_time")]
        string startTime;
        [JsonPropertyName("end_time")]
        string endTime;
        public mainWindow()
        {
            InitializeComponent();
        }

        private void richTextBoxReport_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxReport.Clear();
            richTextBoxReport.Visible = true;
            buttonReport.Visible = true;
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            int indexTask = -1;
            for (int i = 0; i < user.Tasks.Count; i++)
            {
                if (user.Tasks[i].Name == comboBoxTasks.Text)
                {
                    indexTask = i;
                    break;
                }
            }
            user.Tasks[indexTask].Report = richTextBoxReport.Text;
            richTextBoxReport.Clear();
            richTextBoxReport.Visible = false;
            buttonReport.Visible = false;
            //POST
            var json = JsonSerializer.Serialize(new
            {
                user.Tasks[indexTask].Id,
                user.Tasks[indexTask].Report,
            });
            comboBoxTasks.Visible = false;
            labelComboBox.Visible = false;

            // Console.WriteLine(user.Tasks[indexTask].Report);
        }
        private void KBDHook_KeyUp(Hooks.LLKHEventArgs e)
        {
            keys.Remove(e.Keys);
        }
        private void KBDHook_KeyDown(Hooks.LLKHEventArgs e) {
            if (!keys.Contains(e.Keys))
            {
                keys.Add(e.Keys);
                if (keys.Count > 1)
                {
                    text += "+" + e.Keys.ToString();
                }
                else 
                { 
                    text += " " + e.Keys.ToString(); 
                }
            }
        }
        private void buttonStartWork_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            buttonStartWork.Visible = false;
            keys = new List<Keys>();
            Hooks.KBDHook.KeyDown += new Hooks.KBDHook.HookKeyPress(KBDHook_KeyDown);
            Hooks.KBDHook.KeyUp += new Hooks.KBDHook.HookKeyPress(KBDHook_KeyUp);
            Hooks.KBDHook.LocalHook = false;
            Hooks.KBDHook.InstallHook();
            buttonStop.Visible = true;
            startTime = DateTime.Now.ToString();
            comboBoxTasks.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(screenshot);
                graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                MemoryStream stream = new MemoryStream();
                screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                screens.Add(new Tuple<byte[], string>(stream.ToArray(), DateTime.Now.ToString()));
                MySqlCommand command = new MySqlCommand("INSERT INTO `screenshots` (`Login`, `Password`,`Name`, `Image`, `logs`) VALUES (@log, @pass, @date, @img, @logs)", connection);
                command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateTime.Now.ToString();
                command.Parameters.Add("@img", MySqlDbType.Blob).Value = stream.ToArray();
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = user.Login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("logs", MySqlDbType.MediumText).Value = text;
                openConnection();
                command.ExecuteNonQuery();
                closeConnection();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            endTime = DateTime.Now.ToString();
            var json = JsonSerializer.Serialize(new
            {
                startTime,
                endTime,
                screens,
                text
            });
            timer1.Enabled = false;
            timer2.Enabled = false;
            labelClock.Text = "00:00:00";
            //POST

            comboBoxTasks.Enabled = false;
            buttonStop.Visible = false;
            buttonStartWork.Visible = true;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            secondsStart += 1;
            labelClock.Text = secondsStart / 3600 / 10 + "" + secondsStart / 3600 % 10 + ":" + secondsStart % 3600 / 60 / 10 + "" + secondsStart % 3600 / 60 % 10 + ":" + secondsStart % 60 / 10 + "" + secondsStart % 60 % 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTasks.Visible = true;
            labelComboBox.Visible = true;
        }
    }
}
