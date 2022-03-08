namespace TicTacToe
{
    public partial class GameForm : Form
    {
        private Board _board = new Board();
        private StartForm _startForm;

        private GameSymbol _playerSymbol;
        private GameSymbol _AI_Symbol;

        /// <summary>
        /// List of all buttons in the form
        /// </summary>
        private List<Button> buttons = new();
        private void populateButtonsList()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
        }

        public GameForm(int playerSymbol, StartForm startForm)
        {
            InitializeComponent();

            _startForm = startForm;

            populateButtonsList();

            if (Enum.IsDefined(typeof(GameSymbol), playerSymbol))
            {
                switch (playerSymbol)
                {
                    case 0:
                        _playerSymbol = GameSymbol.O;
                        _AI_Symbol = GameSymbol.X;
                        Helper.AI_Move(buttons, _board, _AI_Symbol);
                        break;
                    case 1:
                        _playerSymbol = GameSymbol.X;
                        _AI_Symbol = GameSymbol.O;
                        break;
                    default:
                        break;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Helper.playerMove((Button)sender, _board, _playerSymbol);
                // check if player won
                if (_board.isWinner(_playerSymbol))
                {
                    EndForm endForm = new EndForm("You won!", _startForm, this);
                    endForm.Show();
                    DisableButtons();
                }
                else if (_board.isFull())
                {
                    EndForm endForm = new EndForm("The board is full!", _startForm, this);
                    endForm.Show();
                    DisableButtons();
                }
                else
                {
                    Helper.AI_Move(buttons, _board, _AI_Symbol);
                    // check if AI won
                    if (_board.isWinner(_AI_Symbol))
                    {
                        EndForm endForm = new EndForm("You lost!", _startForm, this);
                        endForm.Show();
                        DisableButtons();
                    }
                    else if (_board.isFull())
                    {
                        EndForm endForm = new EndForm("The board is full!", _startForm, this);
                        endForm.Show();
                        DisableButtons();
                    }
                }
            }
        }

        private void DisableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;    
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
    }
}