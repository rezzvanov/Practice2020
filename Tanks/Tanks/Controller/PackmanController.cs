using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks.Controller
{
    class PackmanController
    {
        private Timer timer = new Timer();
        public int dt { get; }

        PackmanController()
        {
            dt = timer.Interval;
        }

    }
}
