using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PcFirma
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee; 
            progressBar1.MarqueeAnimationSpeed = 30; ControlBox = false;
        }
    }
}
