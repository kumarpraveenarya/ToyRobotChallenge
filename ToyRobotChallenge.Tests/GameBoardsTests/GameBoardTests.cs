using NUnit.Framework;
using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.GameBoards;
using ToyRobotChallenge.Service.GameBoards.Interface;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Tests.GameBoardsTests
{
    public class GameBoardTests
    {
        private IGameBoard gameBoard; 
        [SetUp]
        public void Setup()
        {
            gameBoard = new GameBoard(5, 5);
        }

        [Test]
        public void when_location_Is_Out_Of_Board_Position_Should_Be_Invalid()
        {
            var lastposition = new Position(0, 5);
            var prevLocation = new ToyLocation(lastposition, Direction.South);

            var position = new Position(0, 6);
            var newLocation = new ToyLocation(position, Direction.South);
            var result = gameBoard.GetValidLocation(prevLocation, newLocation);

            Assert.AreEqual(result, prevLocation);
        }

        [Test]
        public void when_location_Is_Inside_Board_Position_Should_Be_valid()
        {
            var lastposition = new Position(0, 2);
            var prevLocation = new ToyLocation(lastposition, Direction.South);

            var position = new Position(1, 2);
            var newLocation = new ToyLocation(position, Direction.South);
            var result = gameBoard.GetValidLocation(prevLocation, newLocation);

            Assert.AreEqual(result, newLocation);
        }
    }
}
