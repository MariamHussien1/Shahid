using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace PhaseTwo_SE
{
    public partial class Form4 : Form
    {
        CrystalReport2 rep2;
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
            private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rep2 = new CrystalReport2();
            crystalReportViewer1.ReportSource = rep2;
            foreach (ParameterDiscreteValue v in rep2.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    rep2.SetParameterValue(0, comboBox1.SelectedItem.ToString());
        //    crystalReportViewer1.ReportSource = rep2;

        //}

        

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            rep2.SetParameterValue(0, comboBox1.SelectedItem.ToString());
            crystalReportViewer1.ReportSource = rep2;
        }
    }
}
