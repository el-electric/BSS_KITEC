using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmDoorClosePopup : Form
    {
        public frmDoorClosePopup(int[] slot)
        {
            InitializeComponent();

            string format = slot[0] + "번 슬롯," + slot[1] + "번 슬롯의 문이 열려있습니다.\n문을 닫아주세요";

            lb_notify.Text = format;

            pictureBox1.Image = global::EL_BSS.Properties.Resources.usingwarning;
        }
    }
}
