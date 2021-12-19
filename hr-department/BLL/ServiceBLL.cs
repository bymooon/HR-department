using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DAL;

namespace BLL
{
    public class ServiceBLL
    {
        public DPContext Context = new();
        public int CountWorkersList => Context.Workers.Count;
        public int CountUnitsList => Context.Units.Count;

        private bool WrongWorkerFullName(string value) => !(new Regex(@"\w+")).IsMatch(value);

        public bool WrongWorkerIndex(int index) => !(index >= 0 && index < CountWorkersList);
        private void WrongWorkerIndexException(int index)
        {
            if (WrongWorkerIndex(index)) throw new Exception("Wrong Index!");
        }
        public void WrongWorkerNameException(string value)
        {
            if (WrongWorkerFullName(value)) throw new Exception("Wrong Name!");
        }
        public void WrongWorkerSurnameException(string value)
        {
            if (WrongWorkerFullName(value)) throw new Exception("Wrong Surname!");
        }
        public void WrongAccountNumberException(string value)
        {
            if (!(new Regex(@"\d{4}-\d{4}-\d{4}-\d{4}")).IsMatch(value)) throw new Exception("Wrong Account number");
        }
        public void WrongPositionException(string value)
        {
            if (!(value == "CEO" || value == "Project Manager" || value == "Team Lead" ||
                    value == "Developer" || value == "Designer" || value == "Trainee")) throw new Exception("Position doesn't exist!");
        }
        public void WrongSeniorityException(int value)
        {
            if (!(new Regex(@"\d")).IsMatch(value.ToString())) throw new Exception("Wrong Seniority");
        }
        public void WrongProjectException(string value)
        {
            if (!(new Regex(@"\w+")).IsMatch(value)) throw new Exception("Wrong Project");
        }

        public int GetWorkerCount() => CountWorkersList;
        public int GetUnitCount() => CountUnitsList;

        public string GetWorkerName(int index, string value = "")
        {
            WrongWorkerIndexException(index);
            if (value == "")
            {
                return Context.Workers[index].Name;
            }
            else
            {
                WrongWorkerNameException(value);
                Context.Workers[index].Name = value;
                return "";
            }
        }
        public string GetWorkerSurname(int index, string value = "")
        {
            WrongWorkerIndexException(index);
            if (value == "")
            {
                return Context.Workers[index].Surname;
            }
            else
            {
                WrongWorkerSurnameException(value);
                Context.Workers[index].Surname = value;
                return "";
            }
        }
        public string GetWorkerAccountNumber(int index, string value = "")
        {
            WrongWorkerIndexException(index);
            if (value == "")
            {
                return Context.Workers[index].AccountNumber;
            }
            else
            {
                WrongAccountNumberException(value);
                Context.Workers[index].AccountNumber = value;
                return "";
            }
        }

        public Position GetPosition(string pos_title)
        {
            Position position = new(Position.Positions.Trainee);
            switch (pos_title)
            {
                case "Trainee":
                    position = new(Position.Positions.Trainee);
                    break;
                case "Designer":
                    position = new(Position.Positions.Designer);
                    break;
                case "Developer":
                    position = new(Position.Positions.Developer);
                    break;
                case "Team Lead":
                    position = new(Position.Positions.TeamLead);
                    break;
                case "Project Manager":
                    position = new(Position.Positions.ProjectManager);
                    break;
                case "CEO":
                    position = new(Position.Positions.CEO);
                    break;
            }
            return position;
        }

        public string GetWorkerPosition(int index, string value = "")
        {
            WrongWorkerIndexException(index);
            if (value == "")
            {
                return Context.Workers[index].Position.ToString();
            }
            else
            {
                WrongPositionException(value);
                Context.Workers[index].Position = GetPosition(value);
                return "";
            }
        }

        public Unit GetUnitByName(string name)
        {
            foreach (var item in Context.Units)
            {
                if (item.UnitTitle == name) return item;
            }
            return null;
        }
        public string GetWorkerUnit(int index, string value = "")
        {
            WrongWorkerIndexException(index);
            if (value == "")
            {
                return Context.Workers[index].Unit.ToString();
            }
            else
            {
                Unit unit = GetUnitByName(value);
                if (unit == null) throw new Exception("Unit is missing");
                Context.Workers[index].Unit = unit;
                return "";
            }
        }
        public double GetWorkerSeniority(int index, int value = 0)
        {
            WrongWorkerIndexException(index);
            if (value == 0) return Context.Workers[index].Seniority;
            else
            {
                WrongSeniorityException(value);
                Context.Workers[index].Seniority = value;
                return 0;
            }
        }
        public string GetWorkerProjects(int index, string value = "")
        {
            WrongWorkerIndexException(index);
            if (value == "")
            {
                return Context.Workers[index].Projects;
            }
            else
            {
                WrongProjectException(value);
                Context.Workers[index].Projects = value;
                return "";
            }
        }
        public string GetUnitName(int index)
        {
            if (index >= 0 && index < CountUnitsList)
            {
                return Context.Units[index].UnitTitle;
            }
            else return "";
        }

        public void AddWorker(string name, string surname, string accNumber = "", string position = "", int seniority = 0, string unit = "", string projects = "")
        {
            WrongWorkerNameException(name);
            WrongWorkerSurnameException(surname);
            WrongAccountNumberException(accNumber);
            WrongPositionException(position);
            WrongSeniorityException(seniority);
            Unit unit1 = GetUnitByName(unit);
            if (!(new Regex(@"\w+")).IsMatch(unit)) throw new Exception("Wrong Unit");
            else if (unit == null) throw new Exception("Missing unit");
            
            Context.AddWorker(new Worker(name, surname, accNumber, unit1, GetPosition(position), seniority, projects));
        }
        public void RemoveWorker(int index)
        {
            if (index > CountWorkersList || index - 1 < 0) throw new Exception("Wrong index");
            else Context.RemoveWorker(index - 1);
        }
        public void WorkingTimePerMonth(string WorkingTime)
        {
            Context.WorkingTimePerMonth(WorkingTime);
        }
        public string SearchByName(string name)
        {
            string result = "";
            foreach (var item in Context.Workers)
            {
                if (item.Name == name)
                    result += item.ToString();
            }
            return result;
        }
        public string SearchBySurname(string surname)
        {
            string result = "";
            foreach (var item in Context.Workers)
            {
                if (item.Surname == surname)
                    result += item.ToString();
            }
            return result;
        }
        public string SearchByUnit(string unit)
        {
            string result = "";
            foreach (var item in Context.Workers)
            {
                if (item.Unit.UnitTitle == unit)
                    result += item.ToString();
            }
            return result;
        }
        public string SearchByMoreInfo(string name, string surname, string unit)
        {
            string result = "";
            foreach (var item in Context.Workers)
            {
                if (item.Name == name && item.Surname == surname && item.Unit.UnitTitle == unit)
                    result += item.ToString();
            }
            return result;
        }

        public bool IsUnique(string name)
        {
            foreach (var item in Context.Units)
            {
                if (item.UnitTitle == name)
                    return false;
            }
            return true;
        }
        public void AddUnit(string addName, int salary)
        {
            if (!new Regex(@"\w+").IsMatch(addName)) throw new Exception("Wrong name");
            if (!new Regex(@"\d+").IsMatch(salary.ToString())) throw new Exception("Wrong salary");
            if (!IsUnique(addName)) throw new Exception("Name is not unique!");
            Context.AddUnit(new Unit(addName, salary));
        }
        public void RemoveUnit(int index)
        {
            if (index - 1 < 0 || CountUnitsList < index) throw new Exception("Wrong index");
            else 
                Context.RemoveUnit(index - 1);
        }
        public string SearchByUnitTitle(string name)
        {
            string result = "";
            foreach (var item in Context.Units)
            {
                if (item.UnitTitle == name)
                    result += item.ToString();
            }
            return result;
        }
        public void ChangeUnitByIndex(int index, string name, int salary)
        {
            if (index > CountUnitsList || index - 1 < 0) throw new Exception("Wrong index");
            else if (!IsUnique(name) && Context.Units[index - 1].UnitTitle != name) throw new Exception("Not unique name!");
            else Context.Units[index - 1] = new Unit(name, salary);
        }
        public void UnitSortByName(List<Unit> units)
        {
            Context.SortUnitByName(units);
        }
        public string ShowUnit()
        {
            string value = "";
            for (int i = 0; i < CountUnitsList; i++)
            {
                value += (i + 1) + ". " + Context.Units[i].ToString() + '\n';
            }
            return value;
        }

        public void SortBy(string type)
        {
            Context.SortWorkerBy(type);
        }
        public string BestWorker()
        {
            int min = int.MinValue;
            Worker bestWr = new();
            foreach (var item in Context.Workers)
            {
                if (item.Seniority > min)
                {
                    min = item.Seniority;
                }
                bestWr = item;
            }
            return bestWr.ToString();
        }
        public string BestPosition()
        {
            double max = double.MinValue;
            Worker best = new();
            foreach (var item in Context.Workers)
            {
                double index = item.Unit.Salary;
                if (index > max)
                {
                    best = item;
                    max = index;
                }
            }
            return best.ToString();
        }
        public void UpdatePosition(int index, double multi)
        {
            if (WrongWorkerIndex(index)) throw new Exception("Wrong index");
            else
                Context.Workers[index].Position.WageMultiplier = multi;
        }
        public void SaveToXml(string filename)
        {
            if (!(new Regex(@"(\w+)\.xml")).IsMatch(filename)) throw new Exception("Wrong filename");
            else DPContext.Save(filename, this);
        }
        public static ServiceBLL LoadFromXml(string filename)
        {
            if (!(new Regex(@"(\w)\.xml")).IsMatch(filename)) throw new Exception("Wrong filename");
            else
            {
                return (ServiceBLL)DPContext.Load(filename, typeof(ServiceBLL));
            }
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < CountWorkersList; i++)
            {
                result += (i + 1) + " " + Context.Workers[i].ToString() + "\n";
            }
            return result;
        }
    }
}
