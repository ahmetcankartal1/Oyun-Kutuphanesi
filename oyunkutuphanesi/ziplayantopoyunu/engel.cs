using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunkutuphanesi.ziplayantopoyunu
{


        public abstract class Engel
        {
            public Label Label { get; }
            protected Engel(Label label) { Label = label; }
        }

        public class StaticEngel : Engel
        {
            public StaticEngel(Label label) : base(label) { }
        }
    
}
