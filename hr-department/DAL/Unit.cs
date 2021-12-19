using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Unit
    {
        public string UnitTitle { get; set; }
        public int Salary { get; set; }

        public Unit() { }
        public Unit(string unitTitle, int salary) 
        { 
            UnitTitle = unitTitle;
            Salary = salary;
        }

        public override string ToString()
        {
            return "Title: " + UnitTitle +
                "   Salary: " + Salary;
        }
    }
}
