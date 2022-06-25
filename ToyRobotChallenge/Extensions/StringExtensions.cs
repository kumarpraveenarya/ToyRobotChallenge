using System;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.Extensions
{
    public static class StringExtensions
    {
        private const int ParameterCount = 3;
        private const int CommandInputCount = 2;

        public static string[] ParseStrings(this string command)
        {
            if (command == null || command.Length <= 0)
                throw new ArgumentException("No Command exist");

            return command?.Split(' ');
        }

        public static string[] CheckInutCount(this string[] input)
        {
            if (input.Length != CommandInputCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            return input;
        }

        public static Position Position(this string[] input)
        {
            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            return new Position(x, y);
        }

        public static Direction Direction(this string[] input)
        {
            Direction direction;
            var commandParams = input[1].Split(',');
            if (!Enum.TryParse(commandParams[commandParams.Length -1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            return direction;
        }

        public static Command Command(this string[] input)
        {
            Command command;
            if (!Enum.TryParse(input[0].ToUpper(), true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");

            return command;
        }

        public static ToyLocation Location(this string[] input)
        {
            input = input.CheckInutCount();
            var position = input.Position();
            var direction = input.Direction();

            return new ToyLocation(position, direction);
        }
    }
}
