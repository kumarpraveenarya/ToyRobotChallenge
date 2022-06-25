using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.Service.Validators
{
    public class BoardValidator : IValidator
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public BoardValidator(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public RobotState GetValidLocation(RobotState previousLocation, RobotState newLocation)
        {
            if(IsValidLocation(newLocation))
                return newLocation;

            return previousLocation;
        }

        private bool IsValidLocation(RobotState location)
        {
            return location.Position.X < Columns && location.Position.X >= 0 &&
                   location.Position.Y < Rows && location.Position.Y >= 0;
        }
    }
}
