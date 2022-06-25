using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Extensions
{
    public static class LocationExtention
    {
        public static ToyLocation Move(this ToyLocation locaton)
        {
            var position = new Position(locaton.Position.X, locaton.Position.Y);
            switch (locaton.Direction)
            {
                case Direction.North:
                    position.Y += 1;
                    break;
                case Direction.East:
                    position.X += 1;
                    break;
                case Direction.South:
                    position.Y -= 1;
                    break;
                case Direction.West:
                    position.X -= 1;
                    break;
            }

            return new ToyLocation(position, locaton.Direction);
        }
    }
}
