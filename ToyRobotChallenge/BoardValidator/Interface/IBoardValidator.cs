using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.BoardValidator.Interface
{
    public interface IBoardValidator
    {
        void SetPlayBoard(int rows, int columns);

        (int, int) GetPlayBoard();

        RobotState GetValidState(RobotState previousLocation, RobotState location);
    }
}
