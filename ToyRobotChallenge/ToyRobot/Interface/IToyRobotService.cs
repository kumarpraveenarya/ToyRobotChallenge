namespace ToyRobotChallenge.Service.ToyRobot.Interface
{
    public interface IToyRobotService
    {
        RobotState State { get; set; }

        IToyRobotService Place(RobotState state);

        IToyRobotService Move { get; }

        IToyRobotService MoveLeft { get; }

        IToyRobotService MoveRight { get; }

        string Report { get; }
    }
}
