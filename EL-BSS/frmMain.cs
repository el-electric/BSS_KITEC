using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
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
            byte[] bytes = new byte[22];

            int idx = 0;
            bytes[0] = 0xfe;

            bytes[1] = 0;
            bytes[2] = 0;

            bytes[3] = 0;

            bytes[4] = 1;

            bytes[5] = 1;

            bytes[6] = (byte)'M';
            bytes[7] = (byte)'S';

            bytes[8] = (byte)'c';
            bytes[9] = (byte)'1';

            bytes[10] = 0;
            bytes[11] = 7;

            bytes[12] = 0;
            bytes[13] = 0;

            bytes[14] = 0;

            bytes[15] = 0;
            bytes[16] = 1;

            bytes[17] = 8;
            ////////////////////////////////////////////

            bytes[18] = 0;

            //////////////////////////////////////////////////
            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);
            bytes[19] = temp[0];
            bytes[20] = temp[1];
            bytes[21] = 0xff;

            sp.Write(bytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Open(drakeUIComboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bytes = new byte[28];

            int idx = 0;
            bytes[0] = 0xfe;

            bytes[1] = 0;
            bytes[2] = 0;

            bytes[3] = 0;

            //master 
            bytes[4] = 0;

            //slave
            bytes[5] = 1;

            bytes[6] = (byte)'M';
            bytes[7] = (byte)'S';

            bytes[8] = (byte)'z';
            bytes[9] = (byte)'1';

            bytes[10] = 0;
            bytes[11] = 13;

            bytes[12] = 0;
            bytes[13] = 1;

            bytes[14] = 0;

            bytes[15] = 0;
            bytes[16] = 1;

            // 도어 열림(슬롯)
            bytes[17] = 2;
            ////////////////////////////////////////////

            bytes[18] = 0;
            bytes[19] = 1;
            bytes[20] = 1;

            bytes[21] = 0;
            bytes[22] = 50;

            bytes[23] = 0;
            bytes[24] = 150;
            //////////////////////////////////////////////////
            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);
            bytes[25] = temp[0];
            bytes[26] = temp[1];
            bytes[27] = 0xff;

            sp.Write(bytes);
        }
    }
}
