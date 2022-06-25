using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Validators.Interface
{
    public interface IBoardValidator
    {
        void SetPlayBoard(int rows, int columns);

        RobotState GetValidState(RobotState previousLocation, RobotState location);
    }
}
