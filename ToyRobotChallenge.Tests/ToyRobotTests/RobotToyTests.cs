using NUnit.Framework;
using Moq;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.GameBoards.Interface;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.ToyRobot.Interface;

namespace ToyRobotChallenge.Tests.ToyRobotTests
{
    public class RobotToyTests
    {
        private IRobotToy _robotToy;
        private Mock<IGameBoard> gameMock;

        [SetUp]
        public void Setup()
        {
            gameMock = new Mock<IGameBoard>();
            _robotToy = new RobotToy(gameMock.Object);
        }

        [Test]
        public void When_location_is_not_valid_do_not_set_Location()
        {
            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(() => null);
            _robotToy.SetLocation(It.IsAny<ToyLocation>());

            Assert.IsNull(_robotToy.Location);
        }

        [Test]
        public void When_location_is_not_valid_set_Location()
        {
            var position = new Position(0, 3);
            var toylocation = new ToyLocation(position, Direction.South);

            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(toylocation);
            _robotToy.SetLocation(toylocation);

            Assert.IsNotNull(_robotToy.Location);
        }

        [Test]
        public void When_Facing_West_TurnLeft_Direction_Should_Be_South()
        {
            var lastpos = new Position(2, 2);
            var lastlocation = new ToyLocation(lastpos, Direction.West);
            var toylocation = new ToyLocation(lastpos, Direction.South);

            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(lastlocation);

            _ = _robotToy.SetLocation(lastlocation);

            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(toylocation);

            _ = _robotToy.MoveLeft;

            Assert.AreEqual(Direction.South, _robotToy.Location.Direction);
        }

        [Test]
        public void When_Facing_West_TurnRight_Direction_Should_Be_North()
        {
            var lastpos = new Position(2, 2);
            var lastlocation = new ToyLocation(lastpos, Direction.West);
            var toylocation = new ToyLocation(lastpos, Direction.North);

            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(lastlocation);

            _ = _robotToy.SetLocation(lastlocation);

            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(toylocation);

            _ = _robotToy.MoveRight;

            Assert.AreEqual(Direction.North, _robotToy.Location.Direction);
        }

        [Test]
        public void When_Position_Is_Valie_Then_Move()
        {
            var position = new Position(2, 3);
            var toylocation = new ToyLocation(position, Direction.East);

            gameMock.Setup(x => x.GetValidLocation(It.IsAny<ToyLocation>(), It.IsAny<ToyLocation>())).Returns(toylocation);

            _ = _robotToy.SetLocation(It.IsAny<ToyLocation>()).Move;

            Assert.AreEqual(2, _robotToy.Location.Position.X);
            Assert.AreEqual(3, _robotToy.Location.Position.Y);
        }
    }
}
