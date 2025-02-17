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
using System.Windows.Media;

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

            if (data == "Attempt to connect to server")
            {
                lb_Title.Text = "Connecting..";
            }
            else
            {
                lb_Title.Text = "Authenticating..";
            }
        }

        public void UpdateForm(string title, string label)
        {
            lb_Title.Text = title;
            lbl_content.Text = label;
        }
    }
}
