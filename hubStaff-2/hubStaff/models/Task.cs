using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubStaff.models
{
    public class Task
    {
        private string name;
        private string project;
        private string report;
        private int id;

        internal string Name
        {
            get
            {
                return name;
            }
        }
        internal string Project
        {
            get
            {
                return project;
            }
        }

        internal string Report
        {
            set
            {
                this.report = value;
            }
            get
            {
                return this.report;
            }
        }

        internal int Id
        {
            get
            {
                return id;
            }
        }

        public Task(int id, string name, string project, string report)
        {
            this.id = id;
            this.name = name;
            this.project = project;
            this.report = report;
        }

    }
}
