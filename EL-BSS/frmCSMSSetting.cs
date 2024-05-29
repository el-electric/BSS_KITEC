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
    public partial class frmCSMSSetting : Form
    {
        public frmCSMSSetting()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "SATIONBOXID", tb_StationBoxID.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "MODEL", tb_Model.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "STATIONID", tb_StationID.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "VENDOR", tb_Vendor.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "COMMUNICATION_MODULE_ID", tb_CmModuleID.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "IMSI", tb_IMSI.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "DETAIL_ADDRESS", tb_detailadress.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "SIMPLE_ADDRESS", tb_simpleadress.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", "MANAGER", tb_Manager.Text);
        }
    }
}
