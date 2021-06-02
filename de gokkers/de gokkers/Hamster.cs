using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de_gokkers
{
    class Hamster
    {
        public int StartingPosition;
        public int RacetrackLength;

        public PictureBox MyPictureBox = null;
        public int Location = 0;

        public Random Randomizer;

        public bool Run(PictureBox racetrack)
        {
            this.MyPictureBox.Left += this.Randomizer.Next(2, 7);
            if (this.MyPictureBox.Right > racetrack.Right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            StartingPosition = 0;
        }
    }
}
