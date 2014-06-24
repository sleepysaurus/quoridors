using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace QuoridorsTests.Models.Services
{
    [TestFixture]
    public class BoardToJsonMapper_Tests
    {
        [Test]
        public void Given_a_valid_input_the_mapper_returns_the_expected_output()
        {
            // Arrange

            // Act

            // Assert

        }

        // TODO what happens if you pass in an invalidly sized array? Can you pass a non-primitive to GetListOfBricks and design that problem out?
        // TODO what happens if you stick invalid values in the array?


        [Test]
        public void GetListOfPlayerPositions_returns_the_value_from_the_repository_mapped_correctly()
        {
            // Arrange
            // TODO create a mock repo, set it up to return data

            // Act

            // Assert

        }
    }
}
