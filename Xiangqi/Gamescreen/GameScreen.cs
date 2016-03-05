using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xiangqi.Gamescreen;

namespace Xiangqi
{
    public partial class GameScreen : Form
    {
        public static int width = 1024;
        public static int height = 800;
        private GameBoard gameBoard;

        public GameScreen()
        {
            InitializeComponent();

            Width = width;
            Height = height;
            CenterToScreen();
            Text = "Xiangqi";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            DoubleBuffered = true;

            gameBoard = new GameBoard();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            gameBoard.Paint(e, label1);          
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            gameBoard.HandleMouseClick(e);
            Refresh();          
        }

        private void ToolBarNewGameClicked(object sender, EventArgs e)
        {
            gameBoard.NewGame();
            Refresh(); 
        }

        private void ToolBarWesternPawnsClicked(object sender, EventArgs e)
        {
            gameBoard.ChangePawnType(1);
            Refresh(); 
        }

        private void ToolBarChinesePawnsClicked(object sender, EventArgs e)
        {
            gameBoard.ChangePawnType(0);
            Refresh(); 
        }

        private void ToolBarCloseGameClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolBarAboutClicked(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
