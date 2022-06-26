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

        public string Report => $"Output: {State.Position.X},{State.Position.Y}, {State.Direction.convertToString()}".ToUpper();

        public IToyRobotService MoveLeft => Rotate(-1);

        public IToyRobotService MoveRight => Rotate(1);

        public IToyRobotService Move => Place(State.Move());

        public override string ToString() => (State == null) ? "Toy Robot is not placed on Game Board" : string.Empty;

        private Direction[] Directions => (Direction[])Enum.GetValues(typeof(Direction));

        private void SetDirection(int rotationNumber) => State.Direction = (State.Direction + rotationNumber) < 0 
                                                                ? Directions[^1] : Directions[(int)(State.Direction + rotationNumber) % Directions.Length];

        public IToyRobotService Place(RobotState state)
        {
            State = _validator.GetValidState(State, state);

            return this;
        }

        private IToyRobotService Rotate(int rotationNumber)
        {
            if (State == null)
                return this;

            SetDirection(rotationNumber);

            return this;
        }
    }
}
