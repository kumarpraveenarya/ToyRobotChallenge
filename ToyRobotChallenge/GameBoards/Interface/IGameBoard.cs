using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.GameBoards.Interface
{
    public interface IGameBoard
    {
        ToyLocation GetValidLocation(ToyLocation previousLocation, ToyLocation location);
    }
}
