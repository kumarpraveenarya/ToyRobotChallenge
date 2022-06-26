using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Extensions
{
    public static class StateExtention
    {
        public static RobotState Move(this RobotState state)
        {
            var position = new Position(state.Position.X, state.Position.Y);
            switch (state.Direction)
            {
                case Direction.North:
                    position.Y -= 1;
                    break;
                case Direction.East:
                    position.X += 1;
                    break;
                case Direction.South:
                    position.Y += 1;
                    break;
                case Direction.West:
                    position.X -= 1;
                    break;
            }

            return new RobotState(position, state.Direction);
        }
    }
}
