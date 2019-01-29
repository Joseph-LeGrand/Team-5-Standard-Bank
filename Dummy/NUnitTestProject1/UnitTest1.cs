using Dummy.Controllers;
using Dummy.Models;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private DummyModelsController _dmC;
        private DummyContext _context;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async System.Threading.Tasks.Task Test1Async()
        {
            //Arrange
            var dummyController = new DummyModelsController(_context);
            //Act
            await dummyController.PostDummyModel("" , "");

            Assert.Pass();
        }
    }
}