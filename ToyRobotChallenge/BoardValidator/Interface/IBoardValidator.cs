using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.BoardValidator.Interface
{
    public interface IBoardValidator
    {
        (int X, int Y) GetPlayBoard { get; }

        void SetPlayBoard(int rows, int columns);

        RobotState GetValidState(RobotState previousLocation, RobotState location);
    }
}
