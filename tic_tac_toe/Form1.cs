using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        bool turn = true; //X= true, Y=false
        bool against_computer = false;
        int turn_count = 0;
            
        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn=true; 
            turn_count=0;

            foreach (Control c in Controls)
            {

                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
            
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by mawadah and fatma", "tic tac toe about");

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b= (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
            // check if playing against computer ,and if it is O turn
            if ((!turn) && (against_computer))
            {
                computer_make_move();
            }
        }
        private void computer_make_move()/////////////////////////
        {
            //1: O get tic tac toe
            //2: block x tic tac toe 
            //3: go for corner space 
            //4: pick open space 

            Button move = null;
            
            move = look_for_win_or_block("O");
            if (move == null)
            {
                move = look_for_win_or_block("X");
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    
                        move = look_for_openspace();
                    
                }
            }
            move.PerformClick();

        }
        private Button look_for_openspace()
        {
            Console.WriteLine("looking for openspace ");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b.Text == "")
                {
                    return b;
                }
            }
            return null;
        }
        private Button look_for_corner()
        {
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (C1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (A1.Text == "")
                    return A1;
            }

            if (C3.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
                if (A1.Text == "")
                    return A1;
            }
            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;
            return null;
        }

        private Button look_for_win_or_block(string mark)////////////////////////
        {
            Console.WriteLine("looking for win or block : " + mark);
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
            {

                return A3;
            }
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
            {

                return A1;
            }
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
            {

                return A2;
            }
            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
            {

                return B3;
            }
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
            {

                return B1;
            }
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
            {

                return B2;
            }
            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
            {

                return C3;
            }
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
            {

                return C1;
            }
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
            {

                return C2;
            }
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
            {
                return C3;
            }
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
            {
                return A1;
            }
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }
            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
            {
                return C1;
            }
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
            {
                return A3;
            }
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }

            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
            {

                return C1;
            }

            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
            {

                return A1;
            }

            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
            {

                return B1;
            }
            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
            {
                return C2;
            }
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
            {
                return A2;
            }
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
            {
                return B2;
            }
            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
            {
                return C3;
            }
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
            {
                return A3;
            }
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
            {
                return B3;
            }
            return null;
        }
        private void checkForWinner()
        {
            bool there_is_a_winner=false;

            if((A1.Text==A2.Text) && (A2.Text==A3.Text) && (!A1.Enabled))
            { 

                there_is_a_winner= true;
            }

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {

                there_is_a_winner = true;
            }

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {

                there_is_a_winner = true;
            }

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {

                there_is_a_winner = true;
            }

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {

                there_is_a_winner = true;
            }

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {

                there_is_a_winner = true;
            }

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {

                there_is_a_winner = true;
            }

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {

                there_is_a_winner = true;
            }
            if (there_is_a_winner)
            {
                disableButtons();
                
                string winner = "";
                if (turn)
                {
                    winner =p2.Text;
                    O_WinScore.Text = (Int32.Parse(O_WinScore.Text) + 1).ToString();
                    
                }
                else
                {
                    winner = textBox1.Text;
                    X_WinScore.Text = (Int32.Parse(X_WinScore.Text) + 1).ToString();
                    
                }
                MessageBox.Show(winner + " Wins !");
                turn = true;
                turn_count = 0;

                foreach (Control c in Controls)
                {

                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }



            }
            else
            {
                if (turn_count == 9)
                {
                    DrawScore.Text = (Int32.Parse(DrawScore.Text) + 1).ToString();
                    MessageBox.Show(" draw !");
                    turn = true;
                    turn_count = 0;

                    foreach (Control c in Controls)
                    {

                        try
                        {
                            Button b = (Button)c;
                            b.Enabled = true;
                            b.Text = "";
                        }
                        catch { }
                    }


                }
            }
        }
        private void disableButtons ()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            } catch  { }

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
            

        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            X_WinScore.Text= "0";
            O_WinScore.Text = "0";
            DrawScore.Text = "0";



        }

        private void p2_TextChanged(object sender, EventArgs e)
        {

            if (p2.Text.ToUpper() == "COMPUTER")
                against_computer = true;
            else
                against_computer = false;
        }

        private void playWithComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p2.Text = "computer";
        }
    }
}
