using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunkutuphanesi.ziplayantopoyunu
{
    public class Platform
    {
        public Button Button { get; }
        private int speed;
        private int leftBound, rightBound;

        public Platform(Button button, int speed, int leftBound, int rightBound)
        {
            Button = button;
            this.speed = speed;
            this.leftBound = leftBound;
            this.rightBound = rightBound - button.Width;
        }

        public void MoveLeft()
        {
            if (Button.Left > leftBound)
                Button.Left -= speed;
        }

        public void MoveRight()
        {
            if (Button.Left < rightBound)
                Button.Left += speed;
        }
    }
}
