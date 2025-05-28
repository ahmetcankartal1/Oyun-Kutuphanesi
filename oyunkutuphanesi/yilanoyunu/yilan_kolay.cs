using System.Drawing;
using System.Windows.Forms;

namespace Oyunkutuphanesi.Yilanoyunu
{
    public class YilanKolay : OyunAlani
    {
        public YilanKolay(Panel panelOyun, Label labelPuan, Label labelSonuc)
            : base(panelOyun, labelPuan, labelSonuc)
        {
        }

        protected override int GetInterval()
        {
            return 300;
        }

        protected override Yilan CreateYilan()
        {
            int startX = (PanelOyun.Width  / 2) / 20 * 20;
            int startY = (PanelOyun.Height / 2) / 20 * 20;
            return new Yilan(new Point(startX, startY));
        }

    }
}
