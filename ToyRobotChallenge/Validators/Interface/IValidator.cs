using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Validators.Interface
{
    public interface IValidator
    {
        RobotState GetValidLocation(RobotState previousLocation, RobotState location);
    }
}
