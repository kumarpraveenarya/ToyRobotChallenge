namespace ToyRobotChallenge.Service.ToyRobot.Interface
{
    public interface IRobotToy
    {
        string Report { get; }

        ToyLocation Location { get; set; }

        IRobotToy SetLocation(ToyLocation location);

        IRobotToy Move { get; }

        IRobotToy MoveLeft { get; }

        IRobotToy MoveRight { get; }
    }
}
