using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Games.Interface
{
    public interface IGameCommand
    {
        string Play(string command);

        RobotState GetRobotState { get; }
    }
}
