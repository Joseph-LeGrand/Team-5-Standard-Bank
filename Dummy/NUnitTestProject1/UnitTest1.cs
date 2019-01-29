using Dummy.Controllers;
using Dummy.Models;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private DummyModelsController _dmC;
        private static DummyModel _context;

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public async System.Threading.Tasks.Task Test1Async(string username)
        {
            //Arrange
            var dummyController = new DummyModelsController();
          
            //Act
            var check = await dummyController.Login(_context);
            //Assert
            Assert.IsTrue(check);
        }
    }
}