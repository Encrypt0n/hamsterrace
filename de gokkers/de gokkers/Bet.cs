using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_gokkers
{
    public class Bet
    {
        public int Amount;
        public int Hamster;
        public Guy Bettor;
        public string GetDescription()
        {
            if (Amount == 0)
            {
                string description = Bettor.Name + " heeft geen weddenschap geplaatst.";
                return description;
            }
            else
            {
                string description = Bettor.Name + " Wedt $" + this.Amount + " op hamster " + (this.Hamster + 1);
                return description;
            }
        }
        public int PayOut(int Winner)
        {
            if (Winner == this.Hamster)
            {
                return this.Amount * 2;
            }
            else
            {
                return -1 * this.Amount;
            }
        }
    }
}
