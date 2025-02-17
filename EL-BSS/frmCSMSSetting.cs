using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EL_BSS.Model;

namespace EL_BSS
{
    public partial class frmCSMSSetting : Form
    {
        public frmCSMSSetting()
        {
            InitializeComponent();
            Model.getInstance().setTouchManger(this);


            //tb_chargePointSerialNumber.Text = Model.getInstance().StationId;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.chargeBoxSerialNumber.ToString(), tb_chargeBoxSerialNumber.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.chargePointModel.ToString(), tb_chargePointModel.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.chargePointSerialNumber.ToString(), tb_chargePointSerialNumber.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.chargePointVendor.ToString(), tb_chargePointVendor.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.iccid.ToString(), tb_iccid.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.imsi.ToString(), tb_imsi.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.stationAddressDetail.ToString(), tb_stationAddressDetail.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.stationAddressConvenient.ToString(), tb_stationAddressConvenient.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.Manager.ToString(), tb_Manager.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.stationLocationLat.ToString(), tb_stationLocationLat.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.stationLocationLong.ToString(), tb_stationLocationLong.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.maker.ToString(), tb_maker.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.makeDate.ToString(), tb_makeDate.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CSMS", enumData.runDate.ToString(), tb_runDate.Text);


            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "COMPORT", "MASTER", cb_master.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "COMPORT", "SLAVE", cb_slave.Text);

            CsUtil.IniWriteValue(Application.StartupPath + @"\web_socet_url.ini", "web_socet_url", "url", tb_CSMS_ADDRESS.Text);

        }

        private void frmCSMSSetting_LoadAsync(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            cb_master.Items.AddRange(port);
            cb_slave.Items.AddRange(port);

            if (!Model.getInstance().Master_PortName.Equals(""))
                cb_master.Text = Model.getInstance().Master_PortName;
            if (!Model.getInstance().Slave_PortName.Equals(""))
                cb_slave.Text = Model.getInstance().Slave_PortName;

            tb_chargeBoxSerialNumber.Text = Model.getInstance().chargeBoxSerialNumber;
            tb_chargePointModel.Text = Model.getInstance().chargePointModel;
            tb_chargePointSerialNumber.Text = Model.getInstance().chargePointSerialNumber;
            tb_chargePointVendor.Text = Model.getInstance().chargePointVendor;
            tb_iccid.Text = Model.getInstance().iccid;
            tb_imsi.Text = Model.getInstance().imsi;
            tb_stationAddressDetail.Text = Model.getInstance().stationAddressDetail;
            tb_stationAddressConvenient.Text = Model.getInstance().stationAddressConvenient;
            tb_Manager.Text = Model.getInstance().Manager;
            tb_CSMS_ADDRESS.Text = CsUtil.IniReadValue(Application.StartupPath + @"\web_socet_url.ini", "web_socet_url", "url", "ws://58.72.4.187:8910/websocket");
        }


    }
}
