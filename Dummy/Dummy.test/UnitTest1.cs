using Dummy.Controllers;
using Dummy.Models;
using NUnit.Framework;
using System.Threading.Tasks;

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
        public void Test()
        {

            //Arrange
            var testLogin = new DummyModelsController();
            //Act
         
            //Assert
        }
    }
}