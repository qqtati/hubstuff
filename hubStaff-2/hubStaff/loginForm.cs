using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hubStaff.models;
namespace hubStaff
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            // GET
            string userName = "test@gmail.com";
            string password = "test123";
            var tasks = new List<models.Task>();
            tasks.Add(new models.Task(1,"Eat some food", "project1", ""));
            tasks.Add(new models.Task(2, "Make a coffee", "project1", ""));
            tasks.Add(new models.Task(3, "Just die", "project2", ""));
            if (textPassword.Text == password && textUsername.Text == userName) {
                this.Hide();
                mainWindow mn = new mainWindow(new User(1, userName, password, "Worker", true, tasks));
                mn.ShowDialog();
            } else
            {
                labelIncorrect.Visible = true;
                textPassword.Text = "";
                textUsername.Text = "";
            }
        }
        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.loginButton_Click(sender, e);
            }
        }

        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                textPassword.Focus();
            }
        }
    }
}
