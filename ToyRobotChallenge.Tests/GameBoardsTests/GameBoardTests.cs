using NUnit.Framework;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.Validators;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.Tests.GameBoardsTests
{
    public class GameBoardTests
    {
        private IValidator _validator; 
        [SetUp]
        public void Setup()
        {
            _validator = new BoardValidator(5, 5);
        }

        [Test]
        public void when_location_Is_Out_Of_Board_Position_Should_Be_Invalid()
        {
            var lastposition = new Position(0, 5);
            var prevLocation = new RobotState(lastposition, Direction.South);

            var position = new Position(0, 6);
            var newLocation = new RobotState(position, Direction.South);
            var result = _validator.GetValidLocation(prevLocation, newLocation);

            Assert.AreEqual(result, prevLocation);
        }

        [Test]
        public void when_location_Is_Inside_Board_Position_Should_Be_valid()
        {
            var lastposition = new Position(0, 2);
            var prevLocation = new RobotState(lastposition, Direction.South);

            var position = new Position(1, 2);
            var newLocation = new RobotState(position, Direction.South);
            var result = _validator.GetValidLocation(prevLocation, newLocation);

            Assert.AreEqual(result, newLocation);
        }
    }
}
