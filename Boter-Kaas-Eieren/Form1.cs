using System;
using System.Drawing;
using System.Windows.Forms;

namespace Boter_Kaas_Eieren
{
    public partial class tic_tac_toe : Form
    {
        private bool win;
        private int XorO;

        public tic_tac_toe()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XorO = 0;
            win = false;

            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button)
                {
                    control.Click += new System.EventHandler(Btn_Click);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Checks if button is clicked
            if (btn.Text.Equals(""))
            {
                // Checks which player's turn it is
                if (XorO % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    labelText.Text = "Waiting for O";
                    CheckWinner();
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Red;
                    labelText.Text = "Waiting for X";
                    CheckWinner();
                }
                XorO++;
            }
        }

        // Resets form
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            XorO = 0;
            win = false;
            labelText.Text = "Play Now";

            // Resets buttons in panel
            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button)
                {
                    control.Text = "";
                    control.BackColor = Color.White;
                    control.Enabled = true;
                }
            }
        }

        // Checks which player wins
        private void CheckWinner()
        {
            // Checks horizontally for winner
            if (!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text))
            {
                SetWinner(button1, button2, button3);
                win = true;
            }
            if (!button4.Text.Equals("") && button4.Text.Equals(button5.Text) && button4.Text.Equals(button6.Text))
            {
                SetWinner(button4, button5, button6);
                win = true;
            }
            if (!button7.Text.Equals("") && button7.Text.Equals(button8.Text) && button7.Text.Equals(button9.Text))
            {
                SetWinner(button7, button8, button9);
                win = true;
            }
            // Checks vertically for winner
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text))
            {
                SetWinner(button1, button4, button7);
                win = true;
            }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text))
            {
                SetWinner(button2, button5, button8);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text))
            {
                SetWinner(button3, button6, button9);
                win = true;
            }
            // Checks diagonally for winner
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text))
            {
                SetWinner(button1, button5, button9);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text))
            {
                SetWinner(button3, button5, button7);
                win = true;
            }

            if (ButtonsTextLength() == 9 && win == false)
            {
                labelText.Text = "No Winner :(";
            }
        }

        // Gets the sum of all the text if the buttons
        private int ButtonsTextLength()
        {
            int buttonsTextlength = 0;

            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button)
                {
                    buttonsTextlength += control.Text.Length;
                }
            }
            return buttonsTextlength;
        }

        // Sets which player wins
        private void SetWinner(Button btn1, Button btn2, Button btn3)
        {
            btn1.BackColor = Color.Green;
            btn2.BackColor = Color.Green;
            btn3.BackColor = Color.Green;

            btn1.ForeColor = Color.White;
            btn2.ForeColor = Color.White;
            btn3.ForeColor = Color.White;

            labelText.Text = btn1.Text + " Wins!";

            // disables all buttons in panel
            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = false;
                }
            }
        }
    }
}