using ToyRobotChallenge.Service.Enums;

namespace ToyRobotChallenge.Service.ToyRobot
{
    public class ToyLocation 
    {
        public Position Position { get; set; }
       public Direction Direction { get; set; }

        public ToyLocation(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
