using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.ToyRobot.Interface;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.Service.ToyRobot
{
    public class ToyRobotService : IToyRobotService
    {
        private readonly IBoardValidator _validator;
        public RobotState State { get; set; }

        public ToyRobotService(IBoardValidator gameBoard)
        {
            _validator = gameBoard;
        }

        public string Report => string.Format("Output: {0},{1},{2}", State.Position.X,
            State.Position.Y, State.Direction.ToString().ToUpper());

        public IToyRobotService MoveLeft => Rotate(-1);

        public IToyRobotService MoveRight => Rotate(1);

        public IToyRobotService Move => Place(State.Move());

        public IToyRobotService Place(RobotState location)
        {
            State = _validator.GetValidState(State, location);

            return this;
        }

        public override string ToString()
        {
            if (State == null)
                return "Toy Robot is not placed on Game Board";

            return string.Empty;
        }

        private IToyRobotService Rotate(int rotationNumber)
        {
            if (State == null)
                return this;

            var directions = (Direction[])Enum.GetValues(typeof(Direction));
           
            if ((State.Direction + rotationNumber) < 0)
                State.Direction = directions[directions.Length - 1];
            else
            {
                var index = ((int)((State.Direction) + rotationNumber)) % directions.Length;
                State.Direction = directions[index];
            }

            return this;
        }
    }
}
