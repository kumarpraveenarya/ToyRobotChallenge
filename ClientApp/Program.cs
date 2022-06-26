using System;
using ToyRobotChallenge.Service.BoardValidator;
using ToyRobotChallenge.Service.BoardValidator.Interface;
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
@" Instructions to Run, defult Grid is 5X5

  1:PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST)
    For Example : PLACE 0,0,SOUTH

  2: After Placing Toy on Grid, use below commands to run the game                    
     REPORT – Shows the current status of the toy. 
     LEFT   – turns the toy 90 degrees left.
     RIGHT  – turns the toy 90 degrees right.
     MOVE   – Moves the toy 1 unit in the facing direction.
     EXIT   – Closes the toy Simulator.
";
            // by default board is set to 5X5
            IBoardValidator board = new BoardValidator();
            
            // playground can be changed by below command
            //board.SetPlayBoard(10,10);
            IToyRobotService robot = new ToyRobotService(board);
            var game = new GameCommand(robot);

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