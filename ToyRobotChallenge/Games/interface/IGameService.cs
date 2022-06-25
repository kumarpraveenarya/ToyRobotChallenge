using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Games.Interface
{
    public interface IGameService
    {
        string Play(string command);

        RobotState GetRobotState();
    }
}
