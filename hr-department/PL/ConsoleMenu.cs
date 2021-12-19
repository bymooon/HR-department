using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    internal class ConsoleMenu
    {
        public static void AddWorkerMenu(ref string Name, ref string Surname, ref string AccountNumber, ref string Unit, ref string Position, ref int Seniority, ref string Projects)
        {
            Console.Clear();
            Console.WriteLine("Enter Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Surname: ");
            Surname = Console.ReadLine();
            Console.WriteLine("Enter account number: ");
            AccountNumber = Console.ReadLine();
            Console.WriteLine("Enter unit: ");
            Unit = Console.ReadLine();
            Console.WriteLine("Enter position:");
            Console.WriteLine("| CEO | Project Manager | Team Lead | Developer | Designer | Trainee |");
            Position = Console.ReadLine();
            Console.WriteLine("Enter seniority: ");
            Seniority = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter projects: ");
            Projects = Console.ReadLine();
        }
        public static void Suspend()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        public static void MainMenu()
        {
            ServiceBLL service = new();
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Choose what you want to work with");
                    Console.WriteLine("Worker | Unit | Position | Save | Load | Exit");
                    switch (Console.ReadLine())
                    {
                        case "Load":
                            {
                                Console.Clear();
                                Console.WriteLine("Enter name of file:");
                                service = ServiceBLL.LoadFromXml(Console.ReadLine());

                                Suspend();
                                break;
                            }
                        case "Save":
                            {
                                Console.Clear();
                                Console.WriteLine("Enter name of file:");
                                service.SaveToXml(Console.ReadLine());

                                Suspend();
                                break;
                            }

                        case "Worker":
                            {
                                Console.Clear();
                                Console.WriteLine("Please, enter the function you want to perform: ");
                                Console.WriteLine("| Add | Search | Delete | Update | Show |  Exit |");
                                switch (Console.ReadLine())
                                {
                                    case "Add":
                                        {
                                            string Name = "", Surname = "", AccountNumber = "", Unit = "", Position = "", Projects = "";
                                            int Seniority = 0;
                                            AddWorkerMenu(ref Name, ref Surname, ref AccountNumber, ref Unit, ref Position, ref Seniority, ref Projects);
                                            service.AddWorker(Name, Surname, AccountNumber, Position, Seniority, Unit, Projects);
                                            Suspend();
                                            break;
                                        }
                                    case "Search":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter way of search: ");
                                            Console.WriteLine("| Name | Surname | Unit |");
                                            switch (Console.ReadLine())
                                            {
                                                case "Name":
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Search by name");
                                                        Console.WriteLine("Enter name: ");
                                                        Console.WriteLine(service.SearchByName(Console.ReadLine()));

                                                        Suspend();
                                                        break;
                                                    }
                                                case "Surname":
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Search by Surname");
                                                        Console.WriteLine("Enter Surname: ");
                                                        Console.WriteLine(service.SearchBySurname(Console.ReadLine()));

                                                        Suspend();
                                                        break;
                                                    }
                                                case "Unit":
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Search by Unit");
                                                        Console.WriteLine("Enter Unit: ");
                                                        Console.WriteLine(service.SearchByUnit(Console.ReadLine()));

                                                        Suspend();
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case "Delete":
                                        {
                                            Console.Clear();
                                            int index;
                                            Console.WriteLine("Chose the index of the item you want to delete: ");
                                            index = int.Parse(Console.ReadLine());
                                            service.RemoveWorker(index);

                                            Suspend();
                                            break;
                                        }
                                    case "Update":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List of workers\n");
                                            Console.WriteLine(service);
                                            Console.WriteLine("Enter index to change:");
                                            int index = int.Parse(Console.ReadLine()) - 1;
                                            Console.WriteLine("Select what you want to change");
                                            Console.WriteLine("| Name | Surname | AccountNumber | Unit | Position | Seniority |");
                                            switch (Console.ReadLine())
                                            {
                                                case "Name":
                                                    {
                                                        Console.WriteLine("Name:");
                                                        service.GetWorkerName(index, Console.ReadLine());
                                                    }
                                                    break;
                                                case "Surname":
                                                    {
                                                        Console.WriteLine("Surname:");
                                                        service.GetWorkerSurname(index, Console.ReadLine());
                                                    }
                                                    break;
                                                case "AccountNumber":
                                                    {
                                                        Console.WriteLine("Account Number:");
                                                        service.GetWorkerAccountNumber(index, Console.ReadLine());
                                                    }
                                                    break;
                                                case "Unit":
                                                    {
                                                        Console.WriteLine("Unit:");
                                                        service.GetWorkerUnit(index, Console.ReadLine());
                                                    }
                                                    break;
                                                case "Position":
                                                    {
                                                        Console.WriteLine("Position:");
                                                        service.GetWorkerPosition(index, Console.ReadLine());
                                                    }
                                                    break;
                                                case "Seniority":
                                                    {
                                                        Console.WriteLine("Seniority:");
                                                        service.GetWorkerSeniority(index, int.Parse(Console.ReadLine()));
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("Unknown!");
                                                    break;
                                            }
                                            Suspend();
                                            break;
                                        }
                                    case "Show":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please, enter how you want to sort the list");
                                            Console.WriteLine("By Name | By Surname | By Salary");
                                            string type = Console.ReadLine();
                                            service.SortBy(type);
                                            Console.WriteLine(service);

                                            Suspend();
                                            break;
                                        }

                                    case "Exit":
                                        {
                                            Console.Clear();
                                            exit = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Unknown command");

                                            Suspend();
                                            break;
                                        }
                                }
                                break;
                            }
                        case "Unit":
                            {
                                Console.Clear();
                                Console.WriteLine("Please, enter the function you want to perform");
                                Console.WriteLine("| Add | Delete | Update | Show | Search | Save | Read | Exit");
                                switch (Console.ReadLine())
                                {
                                    case "Add":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter unit title:");
                                            string UnitTitle = Console.ReadLine();
                                            Console.WriteLine("Enter salary:");
                                            int Salary = int.Parse(Console.ReadLine());
                                            service.AddUnit(UnitTitle, Salary);

                                            Suspend();
                                            break;
                                        }
                                    case "Delete":
                                        {
                                            Console.Clear();
                                            int index;
                                            Console.WriteLine("Choose the index of the item you want to delete:");
                                            index = int.Parse(Console.ReadLine());
                                            service.RemoveUnit(index);

                                            Suspend();
                                            break;
                                        }
                                    case "Update":
                                        {
                                            Console.Clear();
                                            Console.WriteLine(service);
                                            Console.WriteLine("Enter index to change:");
                                            int index = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter name: ");
                                            string UnitTitle = Console.ReadLine();
                                            Console.WriteLine("Enter salary: ");
                                            int Salary = int.Parse(Console.ReadLine());
                                            service.ChangeUnitByIndex(index, UnitTitle, Salary);

                                            Suspend();
                                            break;
                                        }
                                    case "Show":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List of units: ");
                                            Console.WriteLine(service.ShowUnit());

                                            Suspend();
                                            break;
                                        }
                                    case "Search":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Search by title");
                                            Console.WriteLine("Enter unit title: ");
                                            Console.WriteLine(service.SearchByUnitTitle(Console.ReadLine()));

                                            Suspend();
                                            break;
                                        }
                                    case "Exit":
                                        {
                                            Console.Clear();
                                            exit = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Unknown command");
                                            break;
                                        }
                                }
                                break;
                            }
                        case "Position":
                            {
                                Console.Clear();
                                Console.WriteLine("Enter the function you want to perform");
                                Console.WriteLine("| Update | BestWorker | BestPosition | Exit |");
                                switch (Console.ReadLine())
                                {
                                    case "Update":
                                        {
                                            Console.Clear();
                                            Console.WriteLine(service);
                                            Console.WriteLine("Enter the index of worker, which position you want to change:");
                                            int index = int.Parse(Console.ReadLine()) - 1;
                                            Console.WriteLine("Enter the multiplier: ");
                                            double multiply = double.Parse(Console.ReadLine());
                                            service.UpdatePosition(index, multiply);

                                            Suspend();
                                            break;
                                        }
                                    case "BestWorker":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Best worker is: ");
                                            Console.WriteLine(service.BestWorker());

                                            Suspend();
                                            break;
                                        }
                                    case "BestPosition":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Best position is: ");
                                            Console.WriteLine(service.BestPosition());

                                            Suspend();
                                            break;
                                        }
                                    case "Exit":
                                        {
                                            Console.Clear();
                                            exit = true;
                                            break;
                                        }
                                }
                                break;
                            }
                        case "Exit":
                            {
                                exit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Unknown command");
                                break;
                            }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Suspend();
                }
            }
        }
    }
}
