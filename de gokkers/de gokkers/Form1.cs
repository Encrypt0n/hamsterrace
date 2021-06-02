using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de_gokkers
{
    public partial class Form1 : Form
    {
        Guy[] guys = new Guy[4];

        Hamster[] HamsterArray = new Hamster[5];

        public Form1()
        {
            InitializeComponent();

            guys[0] = new Guy() { Cash = 50, Name = "Joe", MyLabel = lblAlessandro, MyRadioButton = radioAlessandro };
            guys[1] = new Guy() { Cash = 100, Name = "Bas", MyLabel = lblBas, MyRadioButton = radioBas };
            guys[2] = new Guy() { Cash = 45, Name = "Al", MyLabel = lblIsabella, MyRadioButton = radioIsabella };
            guys[3] = new Guy() { Cash = 75, Name = "Bob", MyLabel = lblThomas, MyRadioButton = radioThomas };
            foreach (Guy guy in guys)
                guy.PlaceBet(0, 0);

            

            HamsterArray[0] = new Hamster()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width,
                Randomizer = new Random()
            };

            HamsterArray[1] = new Hamster()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = HamsterArray[0].Randomizer
            };

            HamsterArray[2] = new Hamster()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = HamsterArray[0].Randomizer
            };

            HamsterArray[3] = new Hamster()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = HamsterArray[0].Randomizer
            };
            HamsterArray[4] = new Hamster()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox5.Width,
                Randomizer = HamsterArray[0].Randomizer
            };

            updateForm();

        }

        public void updateForm()
        {
            radioAlessandro.Text = guys[0].Name + " heeft $" + guys[0].Cash;
            radioBas.Text = guys[1].Name + " heeft $" + guys[1].Cash;
            radioIsabella.Text = guys[2].Name + " heeft $" + guys[2].Cash;
            radioThomas.Text = guys[3].Name + " heeft $" + guys[2].Cash;
        }


        private void btnRace_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                
                

                foreach (Hamster g in HamsterArray)
                {
                    g.MyPictureBox.Left = g.StartingPosition;
                }
                button1WasClicked = false;

                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Use the Bets button to set your bet first");
            }
        }

        private void radioAlessandro_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[0].Name;
        }

        private void radioBas_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[1].Name;
        }

        private void radioIsabella_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[2].Name;
        }

        private void radioThomas_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[3].Name;
        }

        public bool button1WasClicked = false;

        private void btnBets_Click(object sender, EventArgs e)
        {
            

            button1WasClicked = true;

            int guy;
            if (radioAlessandro.Checked)
            {
                guy = 0;
            }
            else if (radioBas.Checked)
            {
                guy = 1;
            }
            else if (radioIsabella.Checked)
            {
                guy = 2;
            }
            else
            {
                guy = 3;
            }
            guys[guy].PlaceBet((int)numBets.Value, (int)numDog.Value - 1);
            

            Console.WriteLine(guys[guy].Name + " wedt $" + guys[guy].MyBet.Amount + " op hamster " + (guys[guy].MyBet.Hamster + 1));
        }

        public void Collect()
        {
            lblAlessandro.Text = "Joe heeft geen weddenschap geplaatst.";
            lblBas.Text = "Bas heeft geen weddenschap geplaatst.";
            lblIsabella.Text = "Al heeft geen weddenschap geplaatst.";
            lblThomas.Text = "Bob heeft geen weddenschap geplaatst.";
        }

        public void ClearBet()
        {
            numBets.Value = 5;
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int winner;

            for (int i = 0; i < HamsterArray.Length; i++)
            {
                if (HamsterArray[i].Run(racetrackPictureBox))
                {
                    winner = i;
                    timer1.Enabled = false;
                    MessageBox.Show("Hamster #" + (winner + 1) + " Heeft gewonnen!");
                    for (int j = 0; j < guys.Length; j++)
                    {
                        if (guys[j].MyBet.PayOut(winner) != 0)
                            guys[j].Cash += guys[j].MyBet.PayOut(winner);
                        guys[j].MyRadioButton.Text = guys[j].Name + " heeft $" + guys[j].Cash;
                    }
                    Collect();
                    ClearBet();
                    foreach (Hamster g in HamsterArray)
                    {
                        g.MyPictureBox.Left = g.StartingPosition;
                    }
                    break;
                }
            }
        }
        
        
        private void numBets_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void numDog_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblBas_Click(object sender, EventArgs e)
        {

        }

        private void lblAlessandro_Click(object sender, EventArgs e)
        {
            if(lblAlessandro.Enabled)
            {
                MessageBox.Show("easteregg");
            }
        }

        private void lblThomas_Click(object sender, EventArgs e)
        {

        }

        private void racetrackPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
