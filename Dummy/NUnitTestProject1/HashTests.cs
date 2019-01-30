using Dummy.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class HashTests
    {
        [Test]
        public void Untampered_hash_matches_the_text()
        {
            // Arrange
            var message = "passw0rd";
            var salt = Salt.Create();
            var hash = Hash.Create(message, salt);

            // Act
            var match = Hash.Validate(message, salt, hash);

            // Assert
            Assert.True(match);
        }

        [Test]
        public void Tampered_hash_does_not_matche_the_text()
        {
            // Arrange
            var message = "passw0rd";
            var salt = Salt.Create();
            var hash = "blahblahblah";

            // Act
            var match = Hash.Validate(message, salt, hash);

            // Assert
            Assert.False(match);
        }

        [Test]
        public void Hash_of_two_different_messages_dont_match()
        {
            // Arrange
            var message1 = "passw0rd";
            var message2 = "password";
            var salt = Salt.Create();

            // Act
            var hash1 = Hash.Create(message1, salt);
            var hash2 = Hash.Create(message2, salt);

            // Assert
            Assert.True(hash1 != hash2);
        }
    }
}
