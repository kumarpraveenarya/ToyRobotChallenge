using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.ToyRobot.Interface;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.Service.ToyRobot
{
    public class ToyRobotService : IToyRobotService
    {
        private readonly IValidator _validator;
        public RobotState Location { get; set; }

        public ToyRobotService(IValidator gameBoard)
        {
            _validator = gameBoard;
        }

        public string Report => string.Format("Output: {0},{1},{2}", Location.Position.X,
            Location.Position.Y, Location.Direction.ToString().ToUpper());

        public IToyRobotService MoveLeft => Rotate(-1);

        public IToyRobotService MoveRight => Rotate(1);

        public IToyRobotService Move => Place(Location.Move());

        public IToyRobotService Place(RobotState location)
        {
            Location = _validator.GetValidLocation(Location, location);

            return this;
        }

        public override string ToString()
        {
            if (Location == null)
                return "Toy Robot is not placed on Game Board";

            return string.Empty;
        }

        private IToyRobotService Rotate(int rotationNumber)
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
