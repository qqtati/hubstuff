using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubStaff.models
{
    public class User
    {
        private int id;
        private string login;
        private string password;
        private string role;
        private bool status;
        private List<Task> tasks;
        internal string Login {
            get
            {
                return this.login;
            }
        }
        internal string Password
        {
            get
            {
                return this.password;
            }
        }
        internal List<Task> Tasks
        {
            get
            {
                return this.tasks;
            }
        }
        public User(int id, string login, string password, string role, bool status, List<Task> tasks)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
            this.status = status;
            this.tasks = tasks;
        }
    }
}
