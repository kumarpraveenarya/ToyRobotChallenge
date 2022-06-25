using NUnit.Framework;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Games;
using ToyRobotChallenge.Service.Games.Interface;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.Validators;

namespace ToyRobotChallenge.Tests.GamesTests
{
    [TestFixture]
    public class GameTests
    {
        private IGame _game;
       
        [Test]
        public void When_Place_IS_Valid_Then_Set_ToyLocation()
        {
            var toy = new ToyRobotService(new BoardValidator(5, 5));
            _game = new Game(toy);
            _game.Play("PLACE 1,4,EAST");
            
            Assert.AreEqual(1, toy.Location.Position.X);
            Assert.AreEqual(4, toy.Location.Position.Y);
            Assert.AreEqual(Direction.East, toy.Location.Direction);
        }

        [Test]
        public void When_Place_IS_InValid_Then_ToyLocation_Shoud_Be_Null()
        {
            var toy = new ToyRobotService(new BoardValidator(5, 5));
            _game = new Game(toy);
            
            _game.Play("PLACE 9,7,EAST");

            Assert.IsNull(toy.Location);
        }

        [Test]
        public void When_Location_is_Valid_Then_Location_will_Change_in_Report()
        {
            var toy = new ToyRobotService(new BoardValidator(5, 5));
            _game = new Game(toy);

            _game.Play("PLACE 3,2,SOUTH");
            _game.Play("MOVE");

            Assert.AreEqual("Output: 3,1,SOUTH", toy.Report);
        }

        [Test]
        public void When_Location_Is_Out_of_Board_then_Ignore_Move()
        {
            var toy = new ToyRobotService(new BoardValidator(5, 5));
            _game = new Game(toy);

            _game.Play("PLACE 2,2,NORTH");
            _game.Play("MOVE");
            _game.Play("MOVE");
            // if the robot goes out of the board it ignores the command
            _game.Play("MOVE");

            Assert.AreEqual("Output: 2,4,NORTH", toy.Report);
        }

        [Test]
        public void When_Commands_Are_Valid_Reports_Should_Be_Valid()
        {
            var toy = new ToyRobotService(new BoardValidator(5, 5));
            _game = new Game(toy);

            _game.Play("PLACE 3,3,WEST");
            _game.Play("MOVE");
            _game.Play("MOVE");
            _game.Play("LEFT");
            _game.Play("MOVE");
            var output = _game.Play("REPORT");

            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }

    }
}
