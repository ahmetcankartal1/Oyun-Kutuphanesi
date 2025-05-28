using System.Windows.Forms;

namespace Oyunkutuphanesi.Yilanoyunu
{
    public class YilanOrta : YilanKolay
    {
        public YilanOrta(Panel panelOyun, Label labelPuan, Label labelSonuc)
            : base(panelOyun, labelPuan, labelSonuc)
        {
        }

        protected override int GetInterval()
        {
            return 150;
        }
    }
}
