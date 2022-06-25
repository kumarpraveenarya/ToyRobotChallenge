using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.Service.Validators
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
        
        public RobotState GetValidState(RobotState previousLocation, RobotState newLocation)
        {
            if(IsValidState(newLocation))
                return newLocation;

            return previousLocation;
        }

        private bool IsValidState(RobotState location)
        {
            return location.Position.X < Columns && location.Position.X >= 0 &&
                   location.Position.Y < Rows && location.Position.Y >= 0;
        }
    }
}
