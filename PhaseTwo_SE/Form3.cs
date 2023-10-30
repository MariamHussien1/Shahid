using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhaseTwo_SE
{
    public partial class Form3 : Form
    {
        CrystalReport1 rep1;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = rep1;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rep1 = new CrystalReport1();
        }
    }
}
