using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLib.Forms
{
    public partial class ProgressBarDialog : Form
    {
        private int m_nWait = 0;

        public ProgressBarDialog()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                if (++m_nWait > 10)
                {
                    m_nWait = 0;
                    progressBar1.Value = 0;
                }
            }
            else
            {
                progressBar1.Increment(1);
            }
        }
    }
}
