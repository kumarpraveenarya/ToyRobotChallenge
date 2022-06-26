using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;
using ToyRobotChallenge.Service.BoardValidator.Interface;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.Games.Interface;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.ToyRobot.Interface;

namespace ToyRobotChallenge.App
{
	public partial class frmToyRobot : Form
    {
        private readonly IGameCommand game;
        private readonly IBoardValidator boardValidator;
        private readonly IToyRobotService robotService;

		public frmToyRobot(ServiceProvider serviceProvider)
		{
			InitializeComponent();
            boardValidator = serviceProvider.GetRequiredService<IBoardValidator>();
            robotService = serviceProvider.GetRequiredService<IToyRobotService>();
            game = serviceProvider.GetRequiredService<IGameCommand>();
			
			//Tested different dimentions
            //boardValidator.SetPlayBoard(7,7);
			
            FillBoard();
            InitialiseRobot();
		}

		/// <summary>
		/// just for testing felt rows and columns could be same
		/// </summary>
        public void FillBoard()
        {
            var board = boardValidator.GetPlayBoard();
            tlp1.ColumnCount = board.Item1;
            tlp1.RowCount = board.Item2;
            for (int i = 0; i < board.Item1; i++)
            {
                tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			}
        }

		public void InitialiseRobot()
		{
			pbStart.Image = Properties.Resources.Robot_Start;
			pbStart.SizeMode = PictureBoxSizeMode.StretchImage;
			foreach (Direction direction in Enum.GetValues(typeof(Direction)))
			{
				cmbDirection.Items.Add(direction);
			}
		}

		private void btnPlace_Click(object sender, EventArgs e)
		{
            var command = $"PLACE {txtX.Value},{txtY.Value},{cmbDirection.Text}";
            ExecuteCommand(command);
        }
        private void btnMove_Click(object sender, EventArgs e) => ExecuteCommand(Command.Move.convertToString());

        private void btnLeft_Click(object sender, EventArgs e) => ExecuteCommand(Command.Left.convertToString());

        private void btnRight_Click(object sender, EventArgs e) => ExecuteCommand(Command.Right.convertToString());

        private void btnReport_Click(object sender, EventArgs e) => ExecuteCommand(Command.Report.convertToString());

        #region Visual Simulation Logic
        private void PlaceRobotOnMatrix(RobotState state)
		{
			if(state == null) 
                return;

			tlp1.Controls.Clear();
			PictureBox pictureBox = (PictureBox)tlp1.GetControlFromPosition(tlp1.RowCount - state.Position.X, tlp1.ColumnCount - state.Position.Y);
			if (pictureBox == null)
			{
				pictureBox = new PictureBox();
				tlp1.Controls.Add(pictureBox, state.Position.X, state.Position.Y);
			}
			pictureBox.Image = Properties.Resources.Robot;
			switch (state.Direction)
			{
				case Direction.North:
					pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
					break;
				case Direction.East:
					pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
					break;
				case Direction.South:

					break;
				case Direction.West:
					pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
					break;
			}
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			pbStart.Image = null;
		}

        private RobotState ExecuteCommand(string command)
        {
            var result = game.Play(command);

            lblOutputValue.Visible = false;

			// If the operation fails show error
            if (!string.IsNullOrEmpty(result))
            {
                lblOutputValue.Visible = true;
                lblOutputValue.Text = result;
            }
            else
				// if the Domain Operation succeeds place the robot on the table
				PlaceRobotOnMatrix(game.GetRobotState);
			return game.GetRobotState;
		}
        #endregion
	}
}
