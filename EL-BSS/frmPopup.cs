using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmPopup : Form
    {
        public frmPopup()
        {
            InitializeComponent();
        }

        private void drakeUIButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
