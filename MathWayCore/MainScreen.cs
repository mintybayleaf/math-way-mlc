using System;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class MainScreen : UserControl
    {
        private int stats;
        private int math;
        private int other;

        public MainScreen(int m, int s, int o)
        {
            this.stats = s;
            this.math = m;
            this.other = o;
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            this.lblDate.Text = DateTime.Now.ToLongDateString();
            this.lblMath.Text = "Current Math Students - " + this.math.ToString() + " -";
            this.lblStats.Text = "Current Stat Students - " + this.stats.ToString() + " -";
            this.lblOther.Text = "Current Other Students - " + this.other.ToString() + " -";

        }

    
    }
   }

