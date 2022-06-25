using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.GameBoards.Interface;
using ToyRobotChallenge.Service.ToyRobot.Interface;

namespace ToyRobotChallenge.Service.ToyRobot
{
    public class RobotToy : IRobotToy
    {
        private readonly IGameBoard _gameBoard;
        public ToyLocation Location { get; set; }

        public RobotToy(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public string Report => string.Format("Output: {0},{1},{2}", Location.Position.X,
            Location.Position.Y, Location.Direction.ToString().ToUpper());

        public IRobotToy MoveLeft => Rotate(-1);

        public IRobotToy MoveRight => Rotate(1);

        public IRobotToy Move => SetLocation(Location.Move());

        public IRobotToy SetLocation(ToyLocation location)
        {
            Location = _gameBoard.GetValidLocation(Location, location);

            return this;
        }

        public override string ToString()
        {
            if (Location == null)
                return "Toy Robot is not placed on Game Board";

            return string.Empty;
        }

        private IRobotToy Rotate(int rotationNumber)
        {
            if (Location == null)
                return this;

            var directions = (Direction[])Enum.GetValues(typeof(Direction));
           
            if ((Location.Direction + rotationNumber) < 0)
                Location.Direction = directions[directions.Length - 1];
            else
            {
                var index = ((int)((Location.Direction) + rotationNumber)) % directions.Length;
                Location.Direction = directions[index];
            }

            return this;
        }
    }
}
