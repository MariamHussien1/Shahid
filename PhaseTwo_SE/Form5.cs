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
    public partial class Form5 : Form
    {
        CrystalReport3 report;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            report = new CrystalReport3();
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = report;
        }
    }
}
