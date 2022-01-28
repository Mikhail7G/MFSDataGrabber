using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;
using MFSAssistant.Services;


namespace MFSAssistant
{
    public partial class Form1 : Form
    {
        private SimConnectManager Manager;
        public Form1()
        {
            TopMost = true;
            InitializeComponent();
            StartServices();
        }

        public void StartServices()
        {
            Manager = new SimConnectManager(this.Handle);//взаимодействие с симом через simconnect
            Manager.BrakeNotify += Manager_BrakeNotify;
            //таймера оновления приема данных от клиента и управление буксировщиком
            DataUpdateTimer.Start();
            TUGTimer.Start();
        }

        protected override void DefWndProc(ref Message m)//перехват сообщений от окна сима
        {
            if (m.Msg == SimConnectManager.WM_USER_SIMCONNECT)
            {
                if (Manager != null)
                {
                    Manager.ReceiveMessage();
                    OnConnectStatusChange();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void OnConnectStatusChange()
        {
            ConnectLabel.Text = Manager.SimConnectStatus ? "Подключено" : "Клиент не обнаружен";
        }

        private void DataUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Manager.SimConnectStatus)
            {
                Manager.ReqDataFromSim();
            }
        }

        private void GroundServicesMenuBtn_Click(object sender, EventArgs e)
        {//кнопки наземных служб
            if (Manager.SimConnectStatus)
            {
                JetwayBtn.Visible = true;
                CateringBtn.Visible = true;
                LuggageBtn.Visible = true;
                GroundPWRBtn.Visible = true;

                GroundServicesMenuBtn.Visible = false;

                GroundServsBtnBack.Visible = true;
                GroundServsBtnBack.Location = GroundServicesMenuBtn.Location;

                TUGMenuBtn.Visible = false;
            }
        }

        private void GroundServsBtnBack_Click(object sender, EventArgs e)
        {
            JetwayBtn.Visible = false;
            CateringBtn.Visible = false;
            LuggageBtn.Visible = false;
            GroundPWRBtn.Visible = false;

            GroundServicesMenuBtn.Visible = true;
            GroundServsBtnBack.Visible = false;
            TUGMenuBtn.Visible = true;
        }

        private void JetwayBtn_Click(object sender, EventArgs e)
        {
            Manager.TransmitEventToClient(EVENT_ENUM.toggleJetway);
        }

        private void CateringBtn_Click(object sender, EventArgs e)
        {
            Manager.TransmitEventToClient(EVENT_ENUM.toggleCatering);
        }

        private void LuggageBtn_Click(object sender, EventArgs e)
        {
            Manager.TransmitEventToClient(EVENT_ENUM.luggage);
        }

        private void GroundPWRBtn_Click(object sender, EventArgs e)
        {
            Manager.TransmitEventToClient(EVENT_ENUM.toggleGroundPower);
        }

        private void TUGConnBtn_Click(object sender, EventArgs e)
        {
            Manager.ConnectTug();
        }

        private void TUGTimer_Tick(object sender, EventArgs e)
        {
            Manager.UpdateTUG();
            label1.Text = Manager.TugConnected.ToString();
        }

        private void TUGMenuBtn_Click(object sender, EventArgs e)
        {//меню бускировщика
            if (Manager.SimConnectStatus)
            {
                TUGMenuBtn.Visible = false;
                GroundServicesMenuBtn.Visible = false;

                TUGConnBtn.Visible = true;
                TUGBackBtn.Visible = true;
                TUGBackBtn.Location = TUGMenuBtn.Location;
                TUGPauseBtn.Visible = true;
                TugStartPBBtn.Visible = true;
                InfoLabel.Visible = true;
            }
        }

        private void TUGBackBtn_Click(object sender, EventArgs e)
        {
            TUGMenuBtn.Visible = true;
            GroundServicesMenuBtn.Visible = true;

            TUGConnBtn.Visible = false;
            TUGBackBtn.Visible = false;
            TugStartPBBtn.Visible = false;
            TUGPauseBtn.Visible = false;
            InfoLabel.Visible = false;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Manager.TugConnected)//Если в процессе буксировки форма закроется, буксировка прекратится
            {
               Manager.EmerDiscTUG();
            }

        }

        private void TugStartPBBtn_Click(object sender, EventArgs e)
        {
            //INOP
        }

        private void TUGRotation_Tick(object sender, EventArgs e)
        {
           //INOP
        }

        private void TUGPauseBtn_Click(object sender, EventArgs e)
        {
           Manager.StopPB();
        }

        private void Manager_BrakeNotify()
        {
            _= Manager.ParkingBrakeStatus == true ?  TugStartPBBtn.ForeColor = Color.Red : TugStartPBBtn.ForeColor = Color.Green;
        }

    }
}
