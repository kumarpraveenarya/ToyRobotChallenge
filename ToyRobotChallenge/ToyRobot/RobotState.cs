using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;

namespace ToyRobotChallenge.Service.ToyRobot
{
    public class RobotState 
    { 
        public Position Position { get; set; }

        public Direction Direction { get; set; }

        public RobotState(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"Output: {Position.X},{Position.Y},{Direction.convertToString().ToUpper()}"; 
        }
    }
}
