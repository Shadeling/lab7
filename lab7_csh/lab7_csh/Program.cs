using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_csh
{
    class Program
    {

        static List<employee> E = new List<employee>()
        {
            new employee(1, "Abd", 1),
            new employee(2, "Athfd", 1),
            new employee(3, "Adeb", 1),
            new employee(4, "Aetun", 1),
            new employee(5, "Anton", 1),
            new employee(6, "Aeyfbsa", 2),
            new employee(7, "Shgjf", 2),
            new employee(8, "Kvdkgbk", 2),
            new employee(9, "Ae", 2),
            new employee(10, "Tslg", 2),
            new employee(11, "Oncgja", 2),
            new employee(12, "Lsfsa", 2),
            new employee(13, "Nssfh", 2),
            new employee(14, "Kdwhfo", 2),
            new employee(15, "Ubdsk", 3),
            new employee(16, "ARE", 3),
            new employee(17, "Tsbab", 3),
            new employee(18, "Gssqg", 3),
            new employee(19, "Qdhwsgf", 3),
            new employee(20, "Ufjksaka", 3),
            new employee(21, "Ejsfs", 3),
            new employee(22, "Lsbafa", 3),
            new employee(23, "Psass", 3),
            new employee(24, "Nsgfa", 3)
    };
        static List<Department> D = new List<Department>()
        {
            new Department(1, "Sales department"),
            new Department(2, "Management department"),
            new Department(3, "Shopping department")
        };

        static List<Emp_Dep> ED = new List<Emp_Dep>()
        {
            new Emp_Dep(1,1),
            new Emp_Dep(2,1),
            new Emp_Dep(3,1),
            new Emp_Dep(4,1),
            new Emp_Dep(5,1),
            new Emp_Dep(6,2),
            new Emp_Dep(7,2),
            new Emp_Dep(8,2),
            new Emp_Dep(9,2),
            new Emp_Dep(10,2),
            new Emp_Dep(11,2),
            new Emp_Dep(12,2),
            new Emp_Dep(13,2),
            new Emp_Dep(14,2),
            new Emp_Dep(15,3),
            new Emp_Dep(16,3),
            new Emp_Dep(17,3),
            new Emp_Dep(18,3),
            new Emp_Dep(19,3),
            new Emp_Dep(20,3),
            new Emp_Dep(21,3),
            new Emp_Dep(22,3),
            new Emp_Dep(23,3),
            new Emp_Dep(24,3),
        };


        static void Main(string[] args)
        {
            var res1 = D.GroupJoin(E,
                     d => d.departmentID,
                     e => e.departmentID,
                     (dep, emp) => new
                     {
                         ID=dep.departmentID,
                         Title=dep.title,
                         empl=emp.Select(em=>em.name)
                     });
            foreach (var dep in res1)
            {
                Console.WriteLine(dep.ID +"  "+ dep.Title);
                foreach (string emp in dep.empl)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine();
            }

            var res2 = from e in E where e.name[0].Equals('A') select e;
            foreach (var x in res2) Console.WriteLine(x);
            Console.WriteLine();

            var res3 = from d in D
                       join e in E on d.departmentID equals e.departmentID into temp
                       select new { ID = d.departmentID, Title = d.title, count = temp.Count() };
            foreach (var x in res3)  Console.WriteLine(x.ID+"  "+x.Title+"  количество:"+x.count);
            Console.WriteLine();

            var res4 = from d in D
                       join e in E on d.departmentID equals e.departmentID into temp
                       where temp.All(e => e.name[0].Equals('A'))
                       select d;
            foreach (var x in res4) Console.WriteLine(x);
            Console.WriteLine();

            var res5 = from d in D
                       join e in E on d.departmentID equals e.departmentID into temp
                       where temp.Any(e => e.name[0].Equals('A'))
                       select d;
            foreach (var x in res5) Console.WriteLine(x);
            Console.WriteLine();

            var res6 = from d in D
                       join ed in ED on d.departmentID equals ed.IDdep into temp
                       select new { Dep = d, Emp=temp};
            foreach (var x in res6)
            {
                Console.WriteLine(x.Dep.title);
                Console.WriteLine(x.Emp.Count());
                Console.WriteLine();
            }

            var res7 = from d in D
                       join ed in ED on d.departmentID equals ed.IDdep into temp
                       select new { Dep = d, Emp = temp };
            foreach (var x in res7)
            {
                Console.WriteLine(x.Dep.title);
                foreach (Emp_Dep emp in x.Emp)
                {
                    var i = from e in E where e.ID == emp.IDemp select e;
                    foreach(var y in i) Console.WriteLine(y);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

             Console.ReadLine();
        }
    }
}
