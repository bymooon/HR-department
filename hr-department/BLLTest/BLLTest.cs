using System;
using Xunit;
using BLL;

namespace BLLTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestServiceSaveToXml_WrongFileNameException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.SaveToXml("test"));
        }
        [Fact]
        public void TestServiceSaveToXml_CorrectFileName_SaveFile()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            service.SaveToXml("xUnitTest.xml");
            service = ServiceBLL.LoadFromXml("xUnitTest.xml");
            Assert.True(service.CountWorkersList == 1);
        }

        [Fact]
        public void TestServiceLoadFromXml_WrongFileNameException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => ServiceBLL.LoadFromXml("test"));
        }

        [Fact]
        public void ToStringInfo_InfoInitialized_Showed()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.True(service.ToString().Length != 0 && service.ShowUnit().Length != 0);
        }

        [Fact]
        public void TestServiceGetName_WrongIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.Throws<Exception>(() => service.GetWorkerName(100) == "");
        }
        [Fact]
        public void TestServiceGetName_CorrectIndex_True()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            service.GetWorkerName(0, "DD");
            Assert.True(service.GetWorkerName(0) == "DD");
        }
        [Fact]
        public void TestServiceGetSurname_WrongIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.Throws<Exception>(() => service.GetWorkerSurname(100) == "");
        }
        [Fact]
        public void TestServiceGetSurname_CorrectIndex_True()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            service.GetWorkerSurname(0, "DD");
            Assert.True(service.GetWorkerSurname(0) == "DD");
        }
        [Fact]
        public void TestServiceGetAccNumber_WrongIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.Throws<Exception>(() => service.GetWorkerAccountNumber(100) == "");
        }
        [Fact]
        public void TestServiceGetAccNumber_CorrectIndex_True()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            service.GetWorkerAccountNumber(0, "0000-0000-0000-0001");
            Assert.True(service.GetWorkerAccountNumber(0) == "0000-0000-0000-0001");
        }
        [Fact]
        public void TestServiceGetPosition_WrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.Throws<Exception>(() => service.GetWorkerPosition(100) == "");
        }
        [Fact]
        public void TestServiceGetPosition_CorrectIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            service.GetWorkerPosition(0, "CEO");
            Assert.True(service.GetWorkerPosition(0) == "CEO");
        }
        [Fact]
        public void TestServiceGetPosition_WrongPositionException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.Throws<Exception>(() => service.GetWorkerPosition(0, "MMMM"));
        }
        [Fact]
        public void TestServiceGetUnit_WrongIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.Throws<Exception>(() => service.GetWorkerUnit(100) == "");
        }
        [Fact]
        public void TestServiceGetUnit_CorrectIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddUnit("Carbuilding", 1000);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            service.GetWorkerUnit(0, "Carbuilding");
            Assert.True(service.GetWorkerUnit(0) != "");
        }
        [Fact]
        public void TestServiceGetSeniority_CorrectIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");

            service.GetWorkerSeniority(0, 5);

            Assert.True(service.GetWorkerSeniority(0) != 0);
        }
        [Fact]
        public void TestServiceGetSeniority_WrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");

            Assert.Throws<Exception>(() => service.GetWorkerSeniority(100));
        }
        [Fact]
        public void TestServiseGetWorkingProject_CorrectIndex_Exception()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");

            service.GetWorkerProjects(0, "123");

            Assert.True(service.GetWorkerProjects(0) == "123");
        }
        [Fact]
        public void TestServiceCountWorkersList_CorrectDataException()
        {
            ServiceBLL service = new();

            int a = service.CountWorkersList;

            Assert.True(a == service.CountWorkersList);
        }
        [Fact]
        public void TestServiceCountUnitList_CorrectDataException()
        {
            ServiceBLL service = new();

            int a = service.CountUnitsList;

            Assert.True(a == service.CountUnitsList);
        }
        [Fact]
        public void TestServiceGetUnitName_WrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.True(service.GetUnitName(100) == "");
        }
        [Fact]
        public void TestServiceGetUnitName_CorrectIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            Assert.True(service.GetWorkerSurname(0) != "");
        }
        [Fact]
        public void TestServiceGetPosition_TestTrainee_PositionTrainee()
        {
            ServiceBLL service = new();

            Assert.True(service.GetPosition("Trainee").ToString() == "Trainee");
        }
        [Fact]
        public void TestServiceGetPosition_TestCEO_PositionTrainee()
        {
            ServiceBLL service = new();
            service.GetPosition("CEO");
            Assert.True(service.GetPosition("CEO").ToString() == "CEO");
        }
        [Fact]
        
        public void TestServiceGetPosition_TestProjectManager_PositionTrainee()
        {
            ServiceBLL service = new();
            service.GetPosition("Project Manager");
            Assert.True(service.GetPosition("Project Manager").ToString() == "Project Manager");
        }
        [Fact]
        public void TestServiceGetPosition_TestTeamLead_PositionTrainee()
        {
            ServiceBLL service = new();
            service.GetPosition("Team Lead");
            Assert.True(service.GetPosition("Team Lead").ToString() == "Team Lead");
        }
        [Fact]
        public void TestServiceGetPosition_TestDeveloper_PositionTrainee()
        {
            ServiceBLL service = new();
            service.GetPosition("Developer");
            Assert.True(service.GetPosition("Developer").ToString() == "Developer");
        }
        [Fact]
        public void TestServiceWorkingTimePerMounth_WrongTimeException()
        {
            ServiceBLL service = new();
            service.WorkingTimePerMonth("5");

        }
        [Fact]
        public void TestServiceRemoveWorker_WrongIndexException()
        {
            ServiceBLL service = new();
            Assert.Throws<Exception>(() => service.RemoveWorker(0));
        }
        [Fact]
        public void TestServiceRemoveWorker_CorrectIndexException()
        {
            ServiceBLL service = new();
            Assert.Throws<Exception>(() => service.RemoveWorker(1));
        }
        [Fact]
        public void TestServiceAddWorker_WrongNameException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("", "Backham", "3333-3333-3333-3333", "CEO"));
        }
        [Fact]
        public void TestServiceAddWorker_WrongSurnameException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "!!!!", "3333-3333-3333-3333", "CEO"));
        }
        [Fact]
        public void TestServiceAddWorker_WrongAccNumberException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "", "3333-3333-3333", "CEO"));
        }
        [Fact]
        public void TestServiceAddWorker_WrongPositionException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "", "3333-3333-3333-3333", ""));
        }
        [Fact]
        public void TestServiceAddWorker_WrongSeniorityException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "", "3333-3333-3333-3333", "", -1));
        }
        [Fact]
        public void TestServiceAddWorker_WrongWorkingTimeException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "", "3333-3333-3333-3333", "", 2, "s"));
        }
        [Fact]
        public void TestServiceAddWorker_WrongUnitException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "", "3333-3333-3333-3333", "", 2, "8", "s"));
        }
        [Fact]
        /*public void TestServiceAddWorker_WrongProjectsException()
        {
            ServiceBLL service = new();

            Assert.Throws<Exception>(() => service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company"));
        }
        [Fact]*/
        public void TestServiceAddWorker_AddNewWorkerException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");

            bool a = service.GetWorkerCount() != 0;
            Assert.True(a);
        }
        [Fact]
        /*public void TestServiceAddWorker_WrongPositionIException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 500);

            Assert.Throws<Exception>(() => service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company"));
        }
        
        [Fact]*/
        public void TestServiceSearchByName_WrongNameException()
        {
            ServiceBLL service = new();

            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchByName("sdfs");
            Assert.True(str == "");
        }
        [Fact]
        public void TestServiceSearchByName_CorrectNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");

            string str = service.SearchByName("David");
            Assert.True(str != "");
        }
        [Fact]
        public void TestServiceSearchBySecondName_WrongNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchBySurname("vvvv");
            Assert.True(str == "");
        }
        [Fact]
        public void TestServiceSearchBySecondName_CorrectNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchBySurname("Backham");
            Assert.True(str != "");
        }
        [Fact]
        public void TestServiceSearchByUnit_WrongNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchByUnitTitle("David");
            Assert.True(str == "");
        }
        [Fact]
        public void TestServiceSearchByUnit_CorrectNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchByUnit("Build Company");
            Assert.True(str != "");
        }
        [Fact]
        public void TestServiceSearchByMoreInfoWrongNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchByMoreInfo("dfgfd", "", "");
            Assert.True(str == "");
        }
        [Fact]
        public void TestServiceSearchByMoreInfo_CorrectNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 800);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "CEO", 20, "Build Company");
            string str = service.SearchByMoreInfo("David", "Backham", "Build Company");
            Assert.True(str != "");
        }
        
        [Fact]
        public void TestServiceAddServise_FindUnitException()
        {
            ServiceBLL service = new();

            service.AddUnit("Prog", 200);
            service.AddUnit("Prog1", 200);
            Assert.True(service.GetUnitCount() == 2);
        }
        [Fact]
        public void TestServiceRemoveService_WrongIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Prog", 200);
            service.RemoveUnit(1);
            Assert.True(service.GetUnitCount() != 1);
        }
        [Fact]
        public void TestServiceRemoveService_CorrectIndexException()
        {
            ServiceBLL service = new();

            service.AddUnit("Prog", 200);
            service.RemoveUnit(1);
            Assert.True(service.GetUnitCount() != 1);
        }
        
        [Fact]
        public void TestServiceUniqueness2_0_UniqueNameReturnFalse()
        {
            ServiceBLL service = new();

            service.AddUnit("David", 200);
            Assert.True(service.IsUnique("David") == false);
        }
        [Fact]
        public void TestServiceUniqueness2_0_UniqueNameReturnTrue()
        {
            ServiceBLL service = new();

            service.AddUnit("David", 200);
            Assert.True(service.IsUnique("Test") == true);
        }

        [Fact]
        public void TestServiceShowUnit_ShowStringException()
        {
            ServiceBLL service = new();
            service.AddUnit("Vitality", 200);
            Assert.True(service.ShowUnit() != "");
        }
        [Fact]
        public void TestServiceBestWorker_SearchBestOutInfo()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            Assert.True(service.BestWorker() != "");
        }

        [Fact]
        public void RemoveWorker_CorrectIndexTrue()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            service.RemoveWorker(1);

            Assert.True(service.CountWorkersList == 1);
        }
        [Fact]
        public void RemoveWorkerWrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            Assert.Throws<Exception>(() => service.RemoveWorker(100));
        }

        [Fact]
        public void RemoveWorker_SearchByIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            Assert.True(service.SearchByUnitTitle("Build Company") != "");
        }

        [Fact]
        public void ChangeUnitByIndex_ValidDataFound()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);

            service.ChangeUnitByIndex(1, "Fabric", 1000);


            Assert.True(service.SearchByUnitTitle("Fabric").Length != 0);
        }
        [Fact]
        public void ChangeUnitByIndex_WrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            Assert.Throws<Exception>(() => service.ChangeUnitByIndex(1000, "Fabric", 1000));
        }

        [Fact]
        public void ChangeUnitByIndex_WrongNameException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddUnit("Build Company2", 500);
            Assert.Throws<Exception>(() => service.ChangeUnitByIndex(1000, "Build Company2", 1000));
        }

        [Fact]
        public void BestPositionFoundTrue()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            service.UpdatePosition(1, 1.2);

            Assert.True(service.BestPosition().Length != 0);
        }
        [Fact]
        public void UpdatePositionWrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            Assert.Throws<Exception>(() => service.UpdatePosition(100, 1.2));
        }

        [Fact]
        public void SortBy_WrongIndexException()
        {
            ServiceBLL service = new();
            service.AddUnit("Build Company", 500);
            service.AddWorker("David", "Backham", "0000-0000-0000-0000", "Team Lead", 0, "Build Company");
            service.AddWorker("Artem", "Backham", "0000-0000-0000-0000", "CEO", 0, "Build Company");

            service.SortBy("Name");
            service.SortBy("SurName");
            service.SortBy("Unit");

            Assert.Throws<Exception>(() => service.UpdatePosition(100, 1.2));
        }
    }
}
