using Dummy.Controllers;
using Dummy.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
//using Telerik.JustMock;

namespace Dummy.test
{
    class LoginTest
    {
        [Test]
        public void Login_success()
        {
            // Arrange
            var _context = Mock.Of<DummyContext>();
            DummyModelsController controller = new DummyModelsController(_context);
            DummyModel user = new DummyModel
            {
                Id = 1,
                FirstName = "hoe",
                LastName = "hoe",
                Username = "hoe",
                Password = "za4Rv7BJ1fFXIL8y6eEfW4fgVSTaXej9yBackXvqM4E=",
                Salt = "fUiJZ20BzKAfxyuDvAgYQA=="
            };
            // Act
            

            // Assert
            Assert.True(match);
        }
    }
}
