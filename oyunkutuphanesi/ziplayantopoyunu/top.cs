using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunkutuphanesi.ziplayantopoyunu
{
    public class Top
    {
        public Button Button { get; }
        private int dx, dy;

        public Top(Button button, int dx, int dy)
        {
            Button = button;
            this.dx = dx;
            this.dy = dy;
        }

        public void Move()
        {
            Button.Left += dx;
            Button.Top += dy;
        }

        public void BounceHorizontal() => dx = -dx;
        public void BounceVertical() => dy = -dy;

        public bool HitsSide(int leftBound, int rightBound)
            => Button.Left <= leftBound || Button.Right >= rightBound;

        public bool HitsTop(int topBound)
            => Button.Top <= topBound;

        public void IncreaseSpeed(int delta)
        {
            dx += Math.Sign(dx) * delta;
            dy += Math.Sign(dy) * delta;
        }
    }
}