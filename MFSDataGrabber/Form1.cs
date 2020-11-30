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
using System.Runtime.InteropServices;


namespace MFSDataGrabber
{
    public partial class Form1 : Form
    {
        // Компоненты сим коннекта.

        private bool simConnectStatus;
        private SimConnect simConn;

        // Переменная идентификатор Сим Коннекта.
        const int WM_USER_SIMCONNECT = 0x0402;

        // Перечисление для пакетов данных.
        private enum DATA_STRUCT_ENUM
        {
            Plane,
            World
        }

        // Перечесление полученных запросов от Сима
        private enum REQUEST_ENUM
        {
            planeReq,
            worldReq
                
        }

        private enum EVENT_ENUM
        {
            toggleJetway
        }

        private enum SENDER_EVENT_ENUM
        {
            group0
        }

        // Структура данных, получаемая дла самолета
        private struct Plane
        {
            public double heading;
            public double altitude;
            public double speed;
        }

        // Структура данных, получаемая для мира
        private struct World
        {
            public double windPower;
        }


        public Form1()
        {
            InitializeComponent();
            InitalComponents();
        }


        void InitalComponents()
        {
            simConnectStatus = false;
            SimConnectLbl.Text = "Не подключено";

            ConnectStatusChange();
        }

        void ConnectStatusChange()
        {
            SimConnectLbl.Text = simConnectStatus ? "Подключено" : "Не подключено";
            ConnBtn.Text = simConnectStatus ? "Отключить" : "Подключить";
        }

        void Connect()
        {

            try
            {
                // Создаем контроллер обрабоки данных и выбираем данные, которые необходимо получать от сима.

                simConn = new SimConnect("MFSDataGrabber", this.Handle, WM_USER_SIMCONNECT, null, 0);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Plane Heading Degrees True", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Indicated Altitude", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "AIRSPEED TRUE", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.World, "AMBIENT WIND VELOCITY", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.RegisterDataDefineStruct<Plane>(DATA_STRUCT_ENUM.Plane);
                simConn.RegisterDataDefineStruct<World>(DATA_STRUCT_ENUM.World);

                simConn.OnRecvSimobjectDataBytype += OnResiveData;
               
                simConnectStatus = true;

                DataUpdateTimer.Interval = 1500;
                DataUpdateTimer.Start();
                ConnectStatusChange();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        void Disconnect()
        {
            try
            {
                simConn.Dispose();
                simConnectStatus = false;
                ConnectStatusChange();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnBtn_Click(object sender, EventArgs e)
        {
            if(simConnectStatus)
            {
                Disconnect();
            }
            else
            {
                Connect();
            }
        }

        //Переопределение стандартной функции процедуры окна, для получения сообщений от Сим Коннекта.
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simConn != null && simConnectStatus)
                {
                    simConn.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void DataUpdateTimer_Tick(object sender, EventArgs e)
        {
            if(simConnectStatus)
            {
                // Запрашиваем небходимую дату у сима.

                simConn.RequestDataOnSimObjectType(REQUEST_ENUM.planeReq, DATA_STRUCT_ENUM.Plane,0,SIMCONNECT_SIMOBJECT_TYPE.USER);
                simConn.RequestDataOnSimObjectType(REQUEST_ENUM.worldReq, DATA_STRUCT_ENUM.World, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);

            }
        }

        private void OnResiveData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {

            if(data.dwRequestID == 0)
            {
                Plane recData = (Plane)data.dwData[0];
                TrueHeading.Text = recData.heading.ToString();
                Altitude.Text = recData.altitude.ToString();
                Speed.Text = recData.speed.ToString();
            }

            if (data.dwRequestID == 1)
            {
                World recData = (World)data.dwData[0];
                WindPower.Text = recData.windPower.ToString();
            }
        }

        private void JetWayBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleJetway, "TOGGLE_JETWAY");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.toggleJetway, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);



        }
    }
}
