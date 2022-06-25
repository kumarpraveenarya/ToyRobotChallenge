using System;
using ToyRobotChallenge.Service.GameBoards;
using ToyRobotChallenge.Service.GameBoards.Interface;
using ToyRobotChallenge.Service.Games;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.ToyRobot.Interface;

namespace ClientApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string description =
@"  **************************************
  **************************************
  **                                  **
  **        TOY SIMULATOR v1.0        **
  **                                  **
  **************************************
  **************************************

     Welcome!

  1: Place the toy on a 5 x 5 grid
     using the following command:

     PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST)

  2: When the toy is placed, have at go at using
     the following commands.
                
     REPORT – Shows the current status of the toy. 
     LEFT   – turns the toy 90 degrees left.
     RIGHT  – turns the toy 90 degrees right.
     MOVE   – Moves the toy 1 unit in the facing direction.
     EXIT   – Closes the toy Simulator.
";

            IGameBoard board = new GameBoard(5, 5);
            IRobotToy robot = new RobotToy(board);
            var game = new Game(robot);

            var stopApplication = false;
            Console.WriteLine(description);
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = game.Play(command);
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}