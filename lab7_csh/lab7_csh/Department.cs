using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_csh
{
    class Department
    {
        public int departmentID;
        public string title;

        public Department(int a, string b)
        {
            departmentID = a;   title = b;
        }

        public override string ToString()
        {
            return "(ID=" + this.departmentID.ToString() + "; Title=" + this.title + ")";
        }
    }
}
