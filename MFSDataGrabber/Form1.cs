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

        private double planeHeading;
        private double tugRotateAngle = 0;
        private double rotY;

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
            toggleJetway,
            toggleDoor,
            toggleGroundPower,
            toggleCatering,
            simRate,
            startPushBack,
            tugSpeed,
            tugHeading
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
            public double eta;
            public double ete;

            public double rotY;
        }

        // Структура данных, получаемая для мира
        private struct World
        {
            public double windPower;
            public double simRate;
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
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "GPS ETA", "Seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "GPS ETE", "Seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Rotation Velocity Body Y", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.World, "AMBIENT WIND VELOCITY", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.World, "SIMULATION RATE", "Number", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

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
                TrueHeading.Text = Math.Round(recData.heading).ToString();
                Altitude.Text = Math.Round(recData.altitude).ToString();
                Speed.Text = Math.Round(recData.speed).ToString();
            
                TimeSpan tim = TimeSpan.FromSeconds(recData.eta);
                Etalbl.Text = (tim).ToString(@"hh\:mm");

                TimeSpan tim1 = TimeSpan.FromSeconds(recData.ete);
                Etelbl.Text = (tim1).ToString(@"hh\:mm");

                planeHeading = recData.heading;

                rotY = recData.rotY;

            }

            if (data.dwRequestID == 1)
            {
                World recData = (World)data.dwData[0];
                WindPower.Text = recData.windPower.ToString();
                SimRateLbl.Text = recData.simRate.ToString();
            }
        }

        //направление буксировщика
        private uint SetTugHeading(double _angle)
        {
            var hdg = planeHeading;
            hdg += _angle;
            hdg %= 360;
            hdg = hdg * 11930464;

            return (uint)hdg;

        }

        // Подключение jetway к самолету по нажатию кнопки
        private void JetWayBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleJetway, "TOGGLE_JETWAY");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.toggleJetway, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);



        }
        // REQUEST_FUEL_KEY -FUEL
        // REQUEST_POWER_SUPPLY  - External power connection
        // REQUEST_CATERING - catering truck
        private void DoorBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;


            simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleDoor, "TOGGLE_AIRCRAFT_EXIT");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.toggleDoor, 5, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
      
        }

        private void GroundPowerBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleGroundPower, "REQUEST_POWER_SUPPLY");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.toggleGroundPower, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
         }

        private void CateringBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleCatering, "REQUEST_CATERING");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.toggleCatering, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        // Аэропорт вылета и прилета
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FromLbl.Text = textBox1.Text.ToUpper();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Tolbl.Text = textBox2.Text.ToUpper();
        }

        private void PushBackStartBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.startPushBack, "TOGGLE_PUSHBACK");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.startPushBack, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        private void TugTestSpeedBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugSpeed, "KEY_TUG_SPEED");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugSpeed, 0, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        private void TugSpeedFastBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            uint speed = uint.Parse(TUGspeed.Text);

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugSpeed, "KEY_TUG_SPEED");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugSpeed, speed, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        

        private void TugLeftBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugHeading, "KEY_TUG_HEADING");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(+tugRotateAngle), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);

         

            //simConn.SetDataOnSimObject(, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 5);
        }

        private void TugRightBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugHeading, "KEY_TUG_HEADING");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(-tugRotateAngle), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        private void TugBtnBack_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugHeading, "KEY_TUG_HEADING");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(0), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            tugRotateAngle = Double.Parse(TUGAnglebox.Text);


        }

        private void TUGAnglebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
