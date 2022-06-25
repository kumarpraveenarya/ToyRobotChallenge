using NUnit.Framework;
using Moq;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.ToyRobot.Interface;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.Tests.ToyRobotTests
{
    public class RobotToyTests
    {
        private IToyRobotService _robotToy;
        private Mock<IBoardValidator> _boardValidatorMock;

        [SetUp]
        public void Setup()
        {
            _boardValidatorMock = new Mock<IBoardValidator>();
            _robotToy = new ToyRobotService(_boardValidatorMock.Object);
        }

        [Test]
        public void When_location_is_not_valid_do_not_set_Location()
        {
            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(() => null);
            _robotToy.Place(It.IsAny<RobotState>());

            Assert.IsNull(_robotToy.State);
        }

        [Test]
        public void When_location_is_not_valid_set_Location()
        {
            var position = new Position(0, 3);
            var toyLocation = new RobotState(position, Direction.South);

            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toyLocation);
            _robotToy.Place(toyLocation);

            Assert.IsNotNull(_robotToy.State);
        }

        [Test]
        public void When_Facing_West_TurnLeft_Direction_Should_Be_South()
        {
            var lastPosition = new Position(2, 2);
            var lastLocation = new RobotState(lastPosition, Direction.West);
            var toyLocation = new RobotState(lastPosition, Direction.South);

            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(lastLocation);

            _ = _robotToy.Place(lastLocation);

            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toyLocation);

            _ = _robotToy.MoveLeft;

            Assert.AreEqual(Direction.South, _robotToy.State.Direction);
        }

        [Test]
        public void When_Facing_West_TurnRight_Direction_Should_Be_North()
        {
            var lastPosition = new Position(2, 2);
            var lastLocation = new RobotState(lastPosition, Direction.West);
            var toyLocation = new RobotState(lastPosition, Direction.North);

            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(lastLocation);

            _ = _robotToy.Place(lastLocation);

            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toyLocation);

            _ = _robotToy.MoveRight;

            Assert.AreEqual(Direction.North, _robotToy.State.Direction);
        }

        [Test]
        public void When_Position_Is_Valie_Then_Move()
        {
            var position = new Position(2, 3);
            var toyLocation = new RobotState(position, Direction.East);

            _boardValidatorMock.Setup(x => x.GetValidState(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toyLocation);

            _ = _robotToy.Place(It.IsAny<RobotState>()).Move;

            Assert.AreEqual(2, _robotToy.State.Position.X);
            Assert.AreEqual(3, _robotToy.State.Position.Y);
        }
    }
}
