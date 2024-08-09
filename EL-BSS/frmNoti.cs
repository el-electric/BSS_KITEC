using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmNoti : Form, IObserver
    {
        public frmNoti()
        {
            InitializeComponent();

            Model.getInstance().setTouchManger(this);
        }

        public void InitForm()
        {
            
        }

        public void UpdateForm(Model model)
        {
            
        }

        public void UpdateForm(string data)
        {
            lbl_content.Text = data;
        }
    }
}
