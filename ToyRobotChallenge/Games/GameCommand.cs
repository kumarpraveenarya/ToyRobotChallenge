using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.Games.Interface;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.ToyRobot.Interface;

namespace ToyRobotChallenge.Service.Games
{
    public class GameCommand : IGameCommand
    {
        private IToyRobotService _toy { get; }

        public GameCommand(IToyRobotService toy)
        {
            this._toy = toy;
        }

        public string Play(string command)
        {
            var cmd = command.ParseStrings().Command();
            return (cmd switch
            {
                Command.Place => _toy.Place(command.ParseStrings().Location()).ToString(),
                Command.Move => _toy.Move.ToString(),
                Command.Left => _toy.MoveLeft.ToString(),
                Command.Right => _toy.MoveRight.ToString(),
                _ => _toy.Report
            });
        }

        public RobotState GetRobotState => _toy.State;
    }
}
