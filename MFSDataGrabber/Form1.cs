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
        private double RudderDir = 0;
        private double ElevatorDir = 0;
        private double rotY;
        private double TugSpeed = 0;
        private double maxTUGSpeed = 5;

        private double[] ExitTypeArray;

        private uint mainDoor = 0;
        private uint emerDoor = 0;
        private uint cargoDoor = 0;

  
        // Переменная идентификатор Сим Коннекта.
        const int WM_USER_SIMCONNECT = 0x0402;

        // Перечисление для пакетов данных.
        private enum DATA_STRUCT_ENUM
        {
            Plane,
            World,
            ExtitType,
            PushbackWait,
            TugStatus,

            VelocityX,
            VelocityY,
            VelocityZ,
            RotationX,
            RotationY,
            RotationZ,

            RudderPosition
        }

        // Перечесление полученных запросов от Сима
        private enum REQUEST_ENUM
        {
            planeReq,
            worldReq,
            doorReq,
            PushbackReq,
            TugstatusReq
                
        }

        private enum EVENT_ENUM
        {
            toggleJetway,
            toggleGroundPower,
            toggleCatering,
            simRate,
            startPushBack,
            tugSpeed,
            tugHeading,
            luggage,
            door,
            tugDisable
           
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

            public double rudderDirection;
            public double elevatorDirection;
            public bool parkingBrake;
            public bool ASOBOparkingBrake;
        }

        private struct ExitDataStruct
        {
            public double exitdata1;
            public double exitdata2;
            public double exitdata3;
            public double exitdata4;
            public double exitdata5;
            public double exitdata6;
            public double exitdata7;
            public double exitdata8;
            public double exitdata9;
            public double exitdata10;
            public double exitdata11;
            public double exitdata12;
            public double exitdata13;
            public double exitdata14;
            public double exitdata15;
            public double exitdata16;
            public double exitdata17;
            public double exitdata18;
            public double exitdata19;
            public double exitdata20;
        }

        // Структура данных, получаемая для мира
        private struct World
        {
            public double windPower;
            public double simRate;
        }


        public Form1()
        {
            TopMost = true;

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

                ExitTypeArray = new double[20];
                // Создаем контроллер обрабоки данных и выбираем данные, которые необходимо получать от сима.

                simConn = new SimConnect("MFSDataGrabber", this.Handle, WM_USER_SIMCONNECT, null, 0);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Plane Heading Degrees True", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Indicated Altitude", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "AIRSPEED TRUE", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "GPS ETA", "Seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "GPS ETE", "Seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "RUDDER POSITION", "position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "ELEVATOR POSITION", "position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "BRAKE PARKING POSITION", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "A32NX_PARK_BRAKE_LEVER_POS", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.PushbackWait, "Pushback Wait", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.TugStatus, "PUSHBACK ATTACHED", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.VelocityZ, "Velocity Body Z", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                for (uint i=0;i<20;i++)
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.ExtitType, string.Format("Exit Type:{0}", i), "Enum", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.World, "AMBIENT WIND VELOCITY", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.World, "SIMULATION RATE", "Number", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.RegisterDataDefineStruct<Plane>(DATA_STRUCT_ENUM.Plane);
                simConn.RegisterDataDefineStruct<World>(DATA_STRUCT_ENUM.World);
                simConn.RegisterDataDefineStruct<ExitDataStruct>(DATA_STRUCT_ENUM.ExtitType);

                simConn.RegisterDataDefineStruct<int>(DATA_STRUCT_ENUM.PushbackWait);
                simConn.RegisterDataDefineStruct<int>(DATA_STRUCT_ENUM.TugStatus);
      
                simConn.RegisterDataDefineStruct<double>(DATA_STRUCT_ENUM.VelocityZ);

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
                TUGAwaitTimer.Stop();


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
                simConn.RequestDataOnSimObjectType(REQUEST_ENUM.doorReq, DATA_STRUCT_ENUM.ExtitType, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                simConn.RequestDataOnSimObjectType(REQUEST_ENUM.PushbackReq, DATA_STRUCT_ENUM.VelocityZ, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                simConn.RequestDataOnSimObjectType(REQUEST_ENUM.TugstatusReq, DATA_STRUCT_ENUM.TugStatus, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);


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

                // rotY = recData.rotY;

                RudderTxt.Text = Math.Round((recData.rudderDirection), 3).ToString();
                RudderDir = Math.Round((recData.rudderDirection), 3);

                ElevatorLbl.Text= Math.Round((recData.elevatorDirection), 3).ToString();
                ElevatorDir = Math.Round((recData.elevatorDirection), 3);

                brakeStatelbl.Text = (recData.parkingBrake).ToString();
                //   ParkingBrakes.CheckState = CheckState.Checked;
                bool prk = recData.parkingBrake;

                 _ = prk ? (ParkingBrakes.CheckState = CheckState.Checked) : (ParkingBrakes.CheckState = CheckState.Unchecked);

                bool asoboprk = recData.ASOBOparkingBrake;
                _= asoboprk ? (ASOBOparkBrk.CheckState=CheckState.Checked):(ASOBOparkBrk.CheckState = CheckState.Unchecked);

            }

            if (data.dwRequestID == 1)
            {
                World recData = (World)data.dwData[0];
                WindPower.Text = recData.windPower.ToString();
                SimRateLbl.Text = recData.simRate.ToString();
            }


            if(data.dwRequestID==2)
            {
                uint i = 0;
                ExitDataStruct exitData = (ExitDataStruct)data.dwData[0];

                foreach (var field in (exitData.GetType().GetFields()))
                {
                    ExitTypeArray[i] = (double)field.GetValue(exitData);
                    i++;
                }
                SetPlaneDoor();
            }
            if (data.dwRequestID == 3)
            {
                double velz = (double)data.dwData[0];
                VelZlbl.Text = velz.ToString();           
            }

            if (data.dwRequestID == 4)
            {    
                TUGStatusLbl.Text = data.dwData[0].ToString();
            }
        }

        private void SetPlaneDoor()
        {
            mainDoor = (uint)((Array.IndexOf(ExitTypeArray, 0)) + 1);
            cargoDoor = (uint)((Array.IndexOf(ExitTypeArray, 2)));
            emerDoor = (uint)((Array.IndexOf(ExitTypeArray, 1)));
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

        private uint SetTugHeadingReversed()
        {
            var hdg = planeHeading+180;
           // hdg += _angle;
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

        private void DoorOperation(int door)
        {
            if (!simConnectStatus)
                return;
              uint opDoor=0;// 6-cargo;4 -aft, 1-main (A320)

            switch(door)
            {
                case 0:
                    opDoor = mainDoor;
                        break;
                case 1:
                    opDoor = cargoDoor;
                    break;
                case 2:
                    opDoor = emerDoor;
                    break;

            }

            simConn.MapClientEventToSimEvent(EVENT_ENUM.door, "TOGGLE_AIRCRAFT_EXIT");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.door, opDoor, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);

        }
        private void DoorBtn_Click(object sender, EventArgs e)
        {
            DoorOperation(0);

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



            TUGAwaitTimer.Start();
        }

        private void TUGAwaitTimer_Tick(object sender, EventArgs e)
        {
            simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.PushbackWait, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 1);
            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.VelocityZ, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, (double)10);


            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.VelocityX, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.VelocityY, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.VelocityZ, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.RotationX, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.RotationY, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
            //simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.RotationZ, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);

        }


        private void TugTestSpeedBtn_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            //simConn.MapClientEventToSimEvent(EVENT_ENUM.tugSpeed, "KEY_TUG_SPEED");
            //simConn.TransmitClientEvent(0U, EVENT_ENUM.tugSpeed, 0, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
          

            TugRtationTimer.Stop();      
            TUGAwaitTimer.Start();

            TugSpeed = 0;
        }
   
      

        private void TugBtnBack_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            
            simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.PushbackWait, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
           
            //simConn.MapClientEventToSimEvent(EVENT_ENUM.tugHeading, "KEY_TUG_HEADING");
            //simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(0), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);



            TUGAwaitTimer.Stop();
           
            TugRtationTimer.Start();
        }

       

       

        private void button1_Click(object sender, EventArgs e)
        {//загрузка багажа
            if (!simConnectStatus)
                return;

            simConn.MapClientEventToSimEvent(EVENT_ENUM.luggage, "REQUEST_LUGGAGE");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.luggage, SetTugHeading(0), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!simConnectStatus)
                return;

            TugRtationTimer.Stop();
            TUGAwaitTimer.Stop();

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugDisable, "TUG_DISABLE");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugDisable, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        //Функция поворота буксировщика от джойстика
        private void TugRtationTimer_Tick(object sender, EventArgs e)
        {

            if (!simConnectStatus)
                return;
            HDGText.Text = (RudderDir*90).ToString();

            maxTUGSpeed = Double.Parse(TUGspeed.Text);
            TugSpeed += ElevatorDir;
            CurrentTUGSpeedLbl.Text = TugSpeed.ToString(); 

            _= TugSpeed > 0 ? TugSpeed = Math.Min(TugSpeed, maxTUGSpeed) : TugSpeed = Math.Max(TugSpeed, -maxTUGSpeed);
           // TUGspeed.Text = TugSpeed.ToString();

           // SetTugHeading(+RudderDir);

            simConn.MapClientEventToSimEvent(EVENT_ENUM.tugHeading, "KEY_TUG_HEADING");
            simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(+RudderDir*90), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.VelocityZ, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, (double)-TugSpeed);
        }

        private void RudderTxt_Click(object sender, EventArgs e)
        {

        }

        private void CargoBtnDoor_Click(object sender, EventArgs e)
        {
            DoorOperation(1);
        }

        private void EmerDoorBtn_Click(object sender, EventArgs e)
        {
            DoorOperation(2);
        }

        private void HDGText_Click(object sender, EventArgs e)
        {

        }

        private void TUGspeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void TUGspeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
