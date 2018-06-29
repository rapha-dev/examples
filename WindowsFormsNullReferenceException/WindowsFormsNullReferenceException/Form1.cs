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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // new plc instance
            MyPlc = new S7.Net.Plc(S7.Net.CpuType.S71500, "192.168.0.1", 0, 0);

            // connect to PLC
            MyPlc.Open();

            // read a value
            var plcValue = MyPlc.Read("DB8.DBD2");

        }

        ~Form1()
        {
            // close connection on form destroy
            MyPlc.Close();
        }

        public S7.Net.Plc MyPlc;

        /// <summary>
        /// Open a new SubForm
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            SubForm form = new SubForm();
            
            // pass Plc instance to SubForm
            form.MainFormsPlc = MyPlc;

            // show form
            form.Show();
        }
    }
}
