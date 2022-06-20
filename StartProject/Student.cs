using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    //internal class Student
    //{
    //    string name;
    //    public string FirstName { get => name; set => name = value; }
    //    public string LastName { get; set; }

    //    [ValidTest("doc", "exe", "", "", "", "")]
    //    public DateTime DateTime 
    //    { 
    //        get;
    //        set;
    //    }

    //    [ValidTest]
    //    public void Exam(string task) => Console.WriteLine($"Student {LastName} {FirstName} solved {task}");

    //}

    public class Sklad
    {
        public string Name { get; private set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }

        public Sklad(string name)
        {
            Name = name;
        }

        ~Sklad() { }

        public override string ToString()
        {
            return $" Name: { Name }, Cost: { Cost }, Quantity: { Quantity }, Sum: { Quantity* Cost }";
        } 
    }

}
