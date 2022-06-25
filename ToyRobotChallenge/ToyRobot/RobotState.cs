using ToyRobotChallenge.Service.Enums;

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
    }
}
