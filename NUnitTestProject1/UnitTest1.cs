using Dummy.Controllers;
using Dummy.Models;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private DummyModelsController _dmC;
        

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(1, "Test", "Test", "Test", "Test")]
        public async System.Threading.Tasks.Task Test_Logins_Async(int id, string firstName, string lastName, string username, string password)
        {
        //    //Arrange
        //    var dummyController = new DummyModelsController();
        //    var dummyModel = new DummyModel();
        //    private Dummy.Authentication _authentication;
        //private DummyContext _context;

        ////Act
        //var user = _context.UserTest.FirstOrDefault(x => x.Username == dummyModel.Username);
        //var expectedPassword = _authentication.VerifyPassword(dummyModel.Password, user?.Password);
        //await dummyController.Login(_context);
        ////Assert
        //Assert.Pass();
        }
    }
}