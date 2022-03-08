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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void ChooseSide_Click(object sender, EventArgs e)
        {
            int side = int.Parse((sender as Button).AccessibleName);

            GameForm gameForm = new GameForm(side, this);
            gameForm.Show();
            this.Hide();

            //using (GameForm gameForm = new GameForm(side))
            //{
            //    gameForm.Show();

            //    this.Hide();
            //}
        }
    }
}
