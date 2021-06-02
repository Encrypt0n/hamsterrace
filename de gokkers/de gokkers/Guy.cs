using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de_gokkers
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;
        public void UpdateLabels()
        {
            MyLabel.Text = this.MyBet.GetDescription();
        }
        public bool PlaceBet(int amount, int hamster)
        {
            if (this.Cash > amount)
            {
                MyBet = new Bet()
                {
                    Amount = amount,
                    Hamster = hamster,
                    Bettor = this
                };
                UpdateLabels();

                Console.WriteLine(this.Name + " had enough to bet");
                return true;
            }
            else
            {
                Console.WriteLine(this.Name + " didn't have enough to bet");
                return false;
            }
        }
    }
}
