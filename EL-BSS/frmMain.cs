using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmMain : Form, IObserver
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void InitForm()
        {
            string[] port = SerialPort.GetPortNames();
            drakeUIComboBox1.Items.AddRange(port);
        }

        public void UpdateForm(string data, Model model)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp_Slave.Open(drakeUIComboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
