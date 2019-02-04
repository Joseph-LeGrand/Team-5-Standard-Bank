using System.Threading.Tasks;
using Dummy.Controllers;
using Dummy.Models;
using Microsoft.AspNetCore.Mvc;
//using Telerik.JustMock;
using NUnit.Framework;
using NSubstitute;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
//using Moq;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void InitTest()
        {
            //Arrange
            var context = Telerik.JustMock.Mock.Create<DummyContext>();
            DummyModelsController dummyController = new DummyModelsController(context);

            //Act
            string result = dummyController.Init();


            //Assert
            Assert.AreEqual("Intial Test works", result);
        }



        [Test]
        public void Register()
        {
            //Arrange
            var context = Telerik.JustMock.Mock.Create<DummyContext>();
            DummyModelsController dummyController = new DummyModelsController(context);
            
            var dummyModel = Telerik.JustMock.Mock.Create<DummyModel>();
            dummyModel.FirstName = "Mpinane";
            dummyModel.LastName = "Mohale";
            dummyModel.Password = "nane";
            dummyModel.Username = "mpi";

            //Act
            bool addCalled = false;
            bool saveCalled = false;
            Telerik.JustMock.Mock.Arrange(() => context.Add(dummyModel)).DoInstead(() => { addCalled = true;});

            Telerik.JustMock.Mock.Arrange(() => context.SaveChanges()).DoInstead(() => { saveCalled = true;});
  
            var registeredUser = dummyController.Register(dummyModel);
            
            //Assert
            Assert.IsTrue(addCalled && saveCalled);

        }

        [TestCase("mpi", "nane")]
        public void LoginPass(string username, string password)
        {
            //Arrange
            string salt = Salt.Create();
            IQueryable<DummyModel> mockData = new List<DummyModel> {
               new DummyModel {Id = 1, FirstName = "mpinane", LastName = "mohale", Username = "mpi", Password = Hash.Create("nane", salt) , Salt = salt}
            }.AsQueryable();

            var mockSet = new Moq.Mock<DbSet<DummyModel>>();
            mockSet.Setup(m => m.Find(username)).Returns((mockData.Where(x => x.Username == username)).First);

            var mockContext = new Moq.Mock<DummyContext>();
            mockContext.Setup(c => c.DummyModel).Returns(mockSet.Object);

            var controller = new DummyModelsController(mockContext.Object);


            //Act
            var login = controller.Login(username, password).Result;


            //Assert
            Assert.IsInstanceOf<OkObjectResult>(login);
        }

        [TestCase("mpi", "nana")]
        public void LoginFail(string username, string password)
        {
            //Arrange
            string salt = Salt.Create();
            IQueryable<DummyModel> mockData = new List<DummyModel> {
               new DummyModel {Id = 1, FirstName = "mpinane", LastName = "mohale", Username = "mpi", Password = Hash.Create("nane", salt) , Salt = salt}
            }.AsQueryable();

            var mockSet = new Moq.Mock<DbSet<DummyModel>>();
            mockSet.Setup(m => m.Find(username)).Returns((mockData.Where(x => x.Username == username)).First);

            var mockContext = new Moq.Mock<DummyContext>();
            mockContext.Setup(c => c.DummyModel).Returns(mockSet.Object);

            var controller = new DummyModelsController(mockContext.Object);


            //Act
            var login = controller.Login(username, password).Result;


            //Assert
            Assert.IsInstanceOf<UnauthorizedResult>(login);
        }
    }
}