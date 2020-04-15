using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks.View
{
    public class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            this.DoubleBuffered = true;
        }
    }
}
