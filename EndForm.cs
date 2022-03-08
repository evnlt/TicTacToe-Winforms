using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class EndForm : Form
    {
        /// <summary>
        /// First StartForm referance is dragged all the way here to not create new ones everytime and re-use the first one 
        /// </summary>
        private StartForm _startForm;

        /// <summary>
        /// It's here so the played board will not close immediately after the game is finished
        /// </summary>
        private GameForm _gameForm;
        public EndForm(string message, StartForm startForm, GameForm gameForm)
        {
            InitializeComponent();

            this.messageLabel.Text = message;
            _startForm = startForm;
            _gameForm = gameForm;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            _gameForm.Close();
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            _gameForm.Close();
            this.Close();
        }
    }
}
