using Dummy.Controllers;
using Dummy.Models;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private DummyModel _context;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var testLogin = new DummyModelsController.PostDummyModel(_context);
            //Act
            //Assert
        }
    }
}