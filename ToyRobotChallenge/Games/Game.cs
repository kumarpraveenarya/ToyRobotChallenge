using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.Games.Interface;
using ToyRobotChallenge.Service.ToyRobot.Interface;

namespace ToyRobotChallenge.Service.Games
{
    public class Game : IGame
    {
        private IRobotToy _toy { get; }


        public Game(IRobotToy toy)
        {
            this._toy = toy;
        }

        public string Play(string command)
        {
            var cmd = command.ParseStrings().Command();
            return (cmd switch
            {
                Command.Place => _toy.SetLocation(command.ParseStrings().Location()).ToString(),
                Command.Move => _toy.Move.ToString(),
                Command.Left => _toy.MoveLeft.ToString(),
                Command.Right => _toy.MoveRight.ToString(),
                _ => _toy.Report
            });
        }
    }
}
