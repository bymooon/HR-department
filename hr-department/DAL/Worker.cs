using System;


namespace DAL
{
    [Serializable]
    public class Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccountNumber { get; set; }
        public Unit Unit { get; set; }
        public Position Position { get; set; }
        public int Seniority { get; set; }
        public string Projects { get; set; }
        public string WorkingHours { get; set; }

        public Worker(string name, string surname, string accountNumber, Unit unit, Position position, int seniority, string projects)
        {
            Name = name;
            Surname = surname;
            AccountNumber = accountNumber;
            Unit = unit;
            Position = position;
            Seniority = seniority;
            Projects = projects;
        }

        public Worker()
        {
            Name = "";
            Surname = "";
            AccountNumber = "";
            Unit = new Unit();
            Position = new Position();
            Seniority = 0;
            Projects = "";
        }

        public override string ToString()
        {
            string value = Surname + " " + Name +
                "   Account number: " + AccountNumber +
                "   Unit: " + Unit.UnitTitle +
                "   Position: " + Position +
                "   Seniority: " + Seniority +
                "   Salary: " + Position.CalcWage(this);
            return value;
        }

    }

}
