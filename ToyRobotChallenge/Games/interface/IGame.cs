using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Games.Interface
{
    public interface IGame
    {
        string Play(string command);

        RobotState GetRobotState();
    }
}
