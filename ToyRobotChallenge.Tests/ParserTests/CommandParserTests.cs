using NUnit.Framework;
using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;

namespace ToyRobotChallenge.Tests.ParserTests
{
    [TestFixture]
    public class CommandParserTests
    {
        [Test]
        public void When_Input_Command_IsNot_Place_WithPositions_throw_Exception()
        {
            var command = "Next 0,SOUTH";
            var ex = Assert.Throws<ArgumentException>(() => command.ParseStrings().Command());

            Assert.AreEqual("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT", ex.Message);
        }

        [Test]
        public void When_Input_Command_is_PlaceWith_Location_Return_Place()
        {
            var command = "PLACE 0,0,SOUTH";
            var result = command.ParseStrings().Command();

            Assert.AreEqual(Command.Place, result);
        }

        [Test]
        public void When_Input_Command_is_Move_Return_Move()
        {
            var command = "MOVE";
            var result = command.ParseStrings().Command();

            Assert.AreEqual(Command.Move, result);
        }

        [Test]
        public void When_InputCommand_Is_NotAccurate_Throw_Exception()
        {
            var command = string.Empty;
            var ex = Assert.Throws<ArgumentException>(() => command.ParseStrings());

            Assert.AreEqual("No Command exist", ex.Message);
        }

        [Test]
        public void When_ParameterCount_IS_NotAccurate_throw_Exception()
        {
            var command = "Place 0,SOUTH";
            var ex = Assert.Throws<ArgumentException>(() => command.ParseStrings().Location());

            Assert.AreEqual("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F", ex.Message);
        }

        [Test]
        public void When_Direction_IS_NotAccurate_throw_Exception()
        {
            var command = "Place 0,0,OneDirection";
            var ex = Assert.Throws<ArgumentException>(() => command.ParseStrings().Location());      
            
            Assert.AreEqual("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST", ex.Message);
        }

        [Test]
        public void When_Input_IS_Accurate_Return_PlaceCommandParameter()
        {
            var command = "Place 0,0,SOUTH";
            var result = command.ParseStrings().Location();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Direction, Direction.South);
            Assert.AreEqual(result.Position.X, 0);
            Assert.AreEqual(result.Position.Y, 0);
        }
    }
}