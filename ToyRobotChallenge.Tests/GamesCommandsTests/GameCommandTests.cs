using NUnit.Framework;
using ToyRobotChallenge.Service.BoardValidator;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Games;
using ToyRobotChallenge.Service.Games.Interface;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Tests.GamesCommandsTests
{
    [TestFixture]
    public class GameCommandTests
    {
        private IGameCommand _game;
       
        [Test]
        public void When_Place_IS_Valid_Then_Set_ToyLocation()
        {
            var toy = new ToyRobotService(new BoardValidator());
            _game = new GameCommand(toy);
            _game.Play("PLACE 1,4,EAST");
            
            Assert.AreEqual(1, toy.State.Position.X);
            Assert.AreEqual(4, toy.State.Position.Y);
            Assert.AreEqual(Direction.East, toy.State.Direction);
        }

        [Test]
        public void When_Place_IS_InValid_Then_ToyLocation_Shoud_Be_Null()
        {
            var toy = new ToyRobotService(new BoardValidator());
            _game = new GameCommand(toy);
            
            _game.Play("PLACE 9,7,EAST");

            Assert.IsNull(toy.State);
        }

        [Test]
        public void When_Location_is_Valid_Then_Location_will_Change_in_Report()
        {
            var toy = new ToyRobotService(new BoardValidator());
            _game = new GameCommand(toy);

            string[] commands = new string[] { "PLACE 3,2,SOUTH", "MOVE" };
            foreach (var cmd in commands)
                _game.Play(cmd);

            Assert.AreEqual("Output: 3,3,SOUTH", toy.Report);
        }

        [Test]
        public void When_Location_Is_Out_of_Board_then_Ignore_Move()
        {
            var toy = new ToyRobotService(new BoardValidator());
            _game = new GameCommand(toy);

            string[] commands = new string[] { "PLACE 2,2,NORTH","MOVE","MOVE", "MOVE"};
            // 4th Move should be ignored
            foreach (var cmd in commands)
                _game.Play(cmd);

            Assert.AreEqual("Output: 2,0,NORTH", toy.Report);
        }

        [Test]
        public void When_Commands_Are_Valid_Reports_Should_Be_Valid()
        {
            var toy = new ToyRobotService(new BoardValidator());
            _game = new GameCommand(toy);
            var output = string.Empty;

            string[] commands = new string[] { "PLACE 3,3,WEST", "MOVE", "MOVE" ,"LEFT", "MOVE", "REPORT" };
            foreach (var cmd in commands)
                output = _game.Play(cmd);

            Assert.AreEqual("Output: 1,4,SOUTH", output);
        }

    }
}
