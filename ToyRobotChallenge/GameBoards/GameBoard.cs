using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.GameBoards.Interface;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.GameBoards
{
    public class GameBoard : IGameBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public GameBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public ToyLocation GetValidLocation(ToyLocation previousLocation, ToyLocation newLocation)
        {
            if(IsValidLocation(newLocation))
                return newLocation;

            return previousLocation;
        }

        private bool IsValidLocation(ToyLocation location)
        {
            return location.Position.X < Columns && location.Position.X >= 0 &&
                   location.Position.Y < Rows && location.Position.Y >= 0;
        }
    }
}
