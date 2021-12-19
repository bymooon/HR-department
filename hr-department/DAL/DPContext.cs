using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    [Serializable]
    public class DPContext
    {
        public List<Worker> Workers { get; set; }
        public List<Unit> Units { get; set; }

        public DPContext()
        {
            Position position = new Position(Position.Positions.Trainee);
            Worker worker = new();
            Unit unit = new();
            Workers = new List<Worker>();
            Units = new List<Unit>();
        }

        public void AddWorker(Worker worker)
        {
            Workers?.Add(worker);
        }
        public void RemoveWorker(int index)
        {
            Workers?.RemoveAt(index);
        }
        public void AddUnit(Unit unit)
        {
            Units?.Add(unit);
        }
        public void RemoveUnit(int index)
        {
            Units?.RemoveAt(index);
        }
        public int WorkingTimePerMonth(string workingTime) => Convert.ToInt32(workingTime) * 22; // 22 = average working days per month
        public void SortWorkerBy(string value)
        {
            switch (value)
            {
                case "Name":
                    Workers.Sort((worker1, worker2) => string.Compare(worker1.Name, worker2.Name));
                    break;
                case "Surname":
                    Workers.Sort((worker1, worker2) => string.Compare(worker1.Surname, worker2.Surname));
                    break;
                case "Salary":
                    Workers.Sort((worker1, worker2) => string.Compare(Convert.ToString(worker1.Unit.Salary), Convert.ToString(worker2.Unit.Salary)));
                    break;
            }
        }
        public void SortUnitByName(List<Unit> units)
        {
            units.Sort((units1, units2) => string.Compare(units1.UnitTitle, units2.UnitTitle));
        }

        public static void Save(string filename, object obj)
        {
            FileStream fs = new(filename, FileMode.OpenOrCreate);
            XmlSerializer serializer = new(obj.GetType());
            serializer.Serialize(fs, obj);
            fs.Close();
        }
        public static object Load(string filename, Type type)
        {
            FileStream fs = new(filename, FileMode.OpenOrCreate);
            XmlSerializer deserializer = new(type);
            object value = deserializer.Deserialize(fs);
            fs.Close();
            return value;
        }
    }
}
