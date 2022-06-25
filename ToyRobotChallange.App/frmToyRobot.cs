using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;
using ToyRobotChallenge.Service.Enums;
using ToyRobotChallenge.Service.Extensions;
using ToyRobotChallenge.Service.Games.Interface;
using ToyRobotChallenge.Service.ToyRobot;
using ToyRobotChallenge.Service.ToyRobot.Interface;
using ToyRobotChallenge.Service.Validators.Interface;

namespace ToyRobotChallenge.App
{
	public partial class frmToyRobot : Form
    {
        private readonly IGameService game;
        private readonly IBoardValidator boardValidator;
        private readonly IToyRobotService robotService;

		public frmToyRobot(ServiceProvider serviceProvider)
		{
			InitializeComponent();
            boardValidator = serviceProvider.GetRequiredService<IBoardValidator>();
            robotService = serviceProvider.GetRequiredService<IToyRobotService>();
            game = serviceProvider.GetRequiredService<IGameService>();
			
			//Tested different dimentions
            //boardValidator.SetPlayBoard(7,7);
			
            FillBoard();
            InitialiseRobot();
		}

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
            var result = game.Play(command);

			lblOutputLabel.Visible = false;
			lblOutputValue.Visible = false;

			// If the operation fails show error
			if (result != string.Empty)
				MessageBox.Show(string.Join(Environment.NewLine, result.ToString()));
			else
				// if the Domain Operation succeeds place the robot on the table
				PlaceRobotOnMatrix(game.GetRobotState());
		}

		/// <summary>
		///		Reads the <param name="state"></param> of the robot and places it on the tabletop
		/// </summary>
		/// <param name="state">The current state of the Robot. This is used to place the robot on the tabletop</param>
		private void PlaceRobotOnMatrix(RobotState state)
		{
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



		private RobotState ExecuteCommand(Command command)
        {
            var result = game.Play(command.convertToString());

			lblOutputLabel.Visible = false;
			lblOutputValue.Visible = false;

			// If the operation fails show error
			if (result != String.Empty)
				MessageBox.Show(string.Join(Environment.NewLine, result.ToString()));
			else
				// if the Domain Operation succeeds place the robot on the table
				PlaceRobotOnMatrix(game.GetRobotState());
			return game.GetRobotState();
		}

		private void btnMove_Click(object sender, EventArgs e)
		{
			ExecuteCommand(Command.Move);
		}

		private void btnLeft_Click(object sender, EventArgs e)
		{
			ExecuteCommand(Command.Left);
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			ExecuteCommand(Command.Right);
		}

		private void btnReport_Click(object sender, EventArgs e)
        {
            var result = ExecuteCommand(Command.Report);
			if (result != null)
			{
				lblOutputLabel.Visible = true;
				lblOutputValue.Visible = true;
				lblOutputValue.Text = $"{result.Position.X},{result.Position.Y},{result.Direction.convertToString()}";
			}
		}
	}
}
