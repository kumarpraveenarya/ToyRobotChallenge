using System;
using ToyRobotChallenge.Service.BoardValidator.Interface;
using ToyRobotChallenge.Service.ToyRobot;

namespace ToyRobotChallenge.Service.BoardValidator
{
    public class BoardValidator : IBoardValidator
    {
        /// <summary>
        /// default size of the board is 5X5
        /// </summary>
        private int Rows { get; set; } = 5 ;
        private int Columns { get; set; } = 5;

        public void SetPlayBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public (int X,int Y) GetPlayBoard => (Rows, Columns);

        public RobotState GetValidState(RobotState previousLocation, RobotState newLocation) => IsValidState(newLocation) ? newLocation : previousLocation;
        
        private bool IsValidState(RobotState location) => location.Position.X < this.Columns && location.Position.X >= 0 
                                                            && location.Position.Y < this.Rows && location.Position.Y >= 0;
    }
}
