using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_csh
{
    class employee
    {
        public int ID;
        public string name;
        public int departmentID;

        public employee(int a, string b, int c)
        {
            ID = a; name = b;   departmentID = c;
        }
        public override string ToString()
        {
            return "(ID=" + this.ID.ToString() + "; name=" + this.name + "; depID=" + this.departmentID.ToString() + ")";
        }
    }
}
