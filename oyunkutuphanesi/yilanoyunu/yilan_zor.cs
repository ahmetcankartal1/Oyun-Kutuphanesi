using System.Windows.Forms;

namespace Oyunkutuphanesi.Yilanoyunu
{
    public class YilanZor : YilanKolay
    {
        public YilanZor(Panel panelOyun, Label labelPuan, Label labelSonuc)
            : base(panelOyun, labelPuan, labelSonuc)
        {
        }

        protected override int GetInterval()
        {
            return 80;
        }
    }
}
