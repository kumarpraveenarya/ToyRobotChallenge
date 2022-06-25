namespace ToyRobotChallenge.Service.ToyRobot.Interface
{
    public interface IToyRobotService
    {
        RobotState Location { get; set; }

        IToyRobotService Place(RobotState location);

        IToyRobotService Move { get; }

        IToyRobotService MoveLeft { get; }

        IToyRobotService MoveRight { get; }

        string Report { get; }
    }
}
