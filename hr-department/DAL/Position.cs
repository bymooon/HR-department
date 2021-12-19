using System;

namespace DAL
{
    [Serializable]
    public class Position
    {
        public double WageMultiplier { get; set; }
        private Positions _positions;
        
        public enum Positions
        {
            CEO, //chief executive officer
            ProjectManager,
            TeamLead,
            Developer,
            Designer,
            Trainee,
        }

        public Position()
        {
            _positions = Positions.Trainee;
        }

        public Position(Positions p)
        {
            _positions = p;
            switch (_positions)
            {
                case Positions.CEO:
                    WageMultiplier = 6;
                    break;
                case Positions.ProjectManager:
                    WageMultiplier = 4;
                    break;
                case Positions.TeamLead:
                    WageMultiplier = 3;
                    break;
                case Positions.Developer:
                    WageMultiplier = 2.5;
                    break;
                case Positions.Designer:
                    WageMultiplier = 2;
                    break;
                case Positions.Trainee:
                    WageMultiplier = 0.5;
                    break;
            }
        }

        public double CalcWage(Worker worker) => worker.Unit.Salary * WageMultiplier;

        public override string ToString()
        {
            switch (_positions)
            {
                case Positions.CEO:
                    return "CEO";
                case Positions.ProjectManager:
                    return "Project Manager";
                case Positions.TeamLead:
                    return "Team Lead";
                case Positions.Developer:
                    return "Developer";
                case Positions.Designer:
                    return "Designer";
                case Positions.Trainee:
                    return "Trainee";
                default:
                    return "";
            }
        }
    }
}
