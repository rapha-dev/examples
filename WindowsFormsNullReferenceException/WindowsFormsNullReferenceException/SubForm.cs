using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsNullReferenceException
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();
        }

        public S7.Net.Plc MainFormsPlc;

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainFormsPlc != null)
            {
                var value = MainFormsPlc.Read("DB9.DBD2");
            }
        }
    }
}
