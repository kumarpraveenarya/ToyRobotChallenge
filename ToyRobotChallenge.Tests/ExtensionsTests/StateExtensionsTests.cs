using NUnit.Framework;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Tests.ExtensionsTests
{
    [TestFixture]
    public class StateExtensionsTests
    {
        [Test]
        public void when_move_north_then_Y_Goes_Back_1_Step()
        {
            var position = new Position(3, 3);
            RobotState state = new RobotState(position, Direction.North);

            var result = state.Move();

            Assert.AreEqual(2, result.Position.Y);
        }

        [Test]
        public void when_move_south_then_Y_Goes_Forward_1_Step()
        {
            var position = new Position(3, 3);
            RobotState state = new RobotState(position, Direction.South);

            var result = state.Move();

            Assert.AreEqual(4, result.Position.Y);
        }

        [Test]
        public void when_move_east_then_X_Goes_Forward_1_Step()
        {
            var position = new Position(3, 3);
            RobotState state = new RobotState(position, Direction.East);

            var result = state.Move();

            Assert.AreEqual(4, result.Position.X);
        }

        [Test]
        public void when_move_west_then_X_Goes_back_1_Step()
        {
            var position = new Position(3, 3);
            RobotState state = new RobotState(position, Direction.West);

            var result = state.Move();

            Assert.AreEqual(2, result.Position.X);
        }
    }
}