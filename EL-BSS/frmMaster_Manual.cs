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
    public partial class frmMaster_Manual : Form
    {
        public frmMaster_Manual()
        {
            Model.getInstance().setTouchManger(this);

            InitializeComponent();
        }
        public void updateView()
        {
            if (Model.getInstance().list_MasterRecv[0].vibrationWarning) { lb_VibrationWarning_m.Text = "True"; }
            else { lb_VibrationWarning_m.Text = "False"; }
            if (Model.getInstance().list_MasterRecv[0].floodingWarning) { lb_floodingWarning_m.Text = "True"; }
            else { lb_floodingWarning_m.Text = "False"; }

            lb_temp_m.Text = Model.getInstance().list_MasterRecv[0].Charger_UpperTemper.ToString();
            lb_Humidity_m.Text = Model.getInstance().list_MasterRecv[0].Charger_Humidity.ToString();
            lb_VibrationSensor_m.Text = Model.getInstance().list_MasterRecv[0].Charger_WaveSensor.ToString();

            if (Model.getInstance().list_MasterRecv[1].vibrationWarning) { lb_VibrationWarning_s.Text = "True"; }
            else { lb_VibrationWarning_s.Text = "False"; }
            if (Model.getInstance().list_MasterRecv[1].floodingWarning) { lb_floodingWarning_s.Text = "True"; }
            else { lb_floodingWarning_s.Text = "False"; }

            lb_temp_s.Text = Model.getInstance().list_MasterRecv[1].Charger_UpperTemper.ToString();
            lb_Humidity_s.Text = Model.getInstance().list_MasterRecv[1].Charger_Humidity.ToString();
            lb_VibrationSensor_s.Text = Model.getInstance().list_MasterRecv[1].Charger_WaveSensor.ToString();
        }

        private void btn_fan_m_Click(object sender, EventArgs e)
        {
            if (Model.getInstance().list_MasterSend[0].isFan) {Model.getInstance().list_MasterSend[0].isFan = false;}
            else { Model.getInstance().list_MasterSend[0].isFan = true; }
        }

        private void btn_manual_m_Click(object sender, EventArgs e)
        {
            if (Model.getInstance().list_MasterSend[0].hmiManual) {Model.getInstance().list_MasterSend[0].hmiManual = false;}
            else {Model.getInstance().list_MasterSend[0].hmiManual = true;}
        }

        private void btn_BoardReset_m_Click(object sender, EventArgs e)
        { Model.getInstance().list_MasterSend[0].hmiManual = true; }

        private void btn_fan_s_Click(object sender, EventArgs e)
        {
            if (Model.getInstance().list_MasterSend[1].isFan) { Model.getInstance().list_MasterSend[1].isFan = false; }
            else { Model.getInstance().list_MasterSend[1].isFan = true; }
        }

        private void btn_manual_s_Click(object sender, EventArgs e)
        {
            if (Model.getInstance().list_MasterSend[1].hmiManual) { Model.getInstance().list_MasterSend[1].hmiManual = false; }
            else { Model.getInstance().list_MasterSend[1].hmiManual = true; }
        }

        private void btn_BoardReset_s_Click(object sender, EventArgs e)
        {
            Model.getInstance().list_MasterSend[1].hmiManual = true;
        }
    }
}
