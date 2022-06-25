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
        private Mock<IValidator> validatorMock;

        [SetUp]
        public void Setup()
        {
            validatorMock = new Mock<IValidator>();
            _robotToy = new ToyRobotService(validatorMock.Object);
        }

        [Test]
        public void When_location_is_not_valid_do_not_set_Location()
        {
            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(() => null);
            _robotToy.Place(It.IsAny<RobotState>());

            Assert.IsNull(_robotToy.Location);
        }

        [Test]
        public void When_location_is_not_valid_set_Location()
        {
            var position = new Position(0, 3);
            var toylocation = new RobotState(position, Direction.South);

            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toylocation);
            _robotToy.Place(toylocation);

            Assert.IsNotNull(_robotToy.Location);
        }

        [Test]
        public void When_Facing_West_TurnLeft_Direction_Should_Be_South()
        {
            var lastpos = new Position(2, 2);
            var lastlocation = new RobotState(lastpos, Direction.West);
            var toylocation = new RobotState(lastpos, Direction.South);

            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(lastlocation);

            _ = _robotToy.Place(lastlocation);

            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toylocation);

            _ = _robotToy.MoveLeft;

            Assert.AreEqual(Direction.South, _robotToy.Location.Direction);
        }

        [Test]
        public void When_Facing_West_TurnRight_Direction_Should_Be_North()
        {
            var lastpos = new Position(2, 2);
            var lastlocation = new RobotState(lastpos, Direction.West);
            var toylocation = new RobotState(lastpos, Direction.North);

            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(lastlocation);

            _ = _robotToy.Place(lastlocation);

            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toylocation);

            _ = _robotToy.MoveRight;

            Assert.AreEqual(Direction.North, _robotToy.Location.Direction);
        }

        [Test]
        public void When_Position_Is_Valie_Then_Move()
        {
            var position = new Position(2, 3);
            var toylocation = new RobotState(position, Direction.East);

            validatorMock.Setup(x => x.GetValidLocation(It.IsAny<RobotState>(), It.IsAny<RobotState>())).Returns(toylocation);

            _ = _robotToy.Place(It.IsAny<RobotState>()).Move;

            Assert.AreEqual(2, _robotToy.Location.Position.X);
            Assert.AreEqual(3, _robotToy.Location.Position.Y);
        }
    }
}
