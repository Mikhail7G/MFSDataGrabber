using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;
using MFSAssistant.Extensions;

namespace MFSAssistant.Services
{
    public class SimConnectManager
    {
        private SimConnect simConn;
        ExternalDataManager DataManager;
        public Plane PlayerControlledAfc;//управляемый игроком самолет
        public bool TugConnected { set; get; }//подключен ли тягач
        public bool ParkingBrakeStatus { set; get; }//стояночный тормоз

        public bool SimConnectStatus { set; get; }
        private double A320brk { set; get; }//индивидуально для модели A320 FBW
        public const string A320FBW_BRAKES = "A32NX_PARK_BRAKE_LEVER_POS";

        private double tugSpeed = 0;//скорость буксировщика
        public double MaxTugSdeed { set; get; }

        public const int WM_USER_SIMCONNECT = 0x0402;//окно сима

        public delegate void ParkBrakeHadler();
        public event ParkBrakeHadler BrakeNotify;
        public bool StartAutoPB { set; get; }//INOP

        public SimConnectManager(IntPtr hWind)
        {
            try
            {
                //инициализируем библиотеки и привязку данных для получения от симулятора

                MaxTugSdeed = 5;

                PlayerControlledAfc = new Plane();

                DataManager = new ExternalDataManager(hWind);
                DataManager.AddDataToDefenition(typeof(bool), A320FBW_BRAKES);

                simConn = new SimConnect("MFSAssistant", hWind, WM_USER_SIMCONNECT, null, 0);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Plane Heading Degrees True", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "Indicated Altitude", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "AIRSPEED TRUE", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "GPS ETA", "Seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "GPS ETE", "Seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "RUDDER POSITION", "position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "ELEVATOR POSITION", "position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.Plane, "BRAKE PARKING POSITION", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.PushbackWait, "Pushback Wait", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.TugStatus, "PUSHBACK ATTACHED", "Bool", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.RotationY, "ROTATION VELOCITY BODY Y", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.RotationX, "ROTATION VELOCITY BODY X", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConn.AddToDataDefinition(DATA_STRUCT_ENUM.VelocityZ, "Velocity Body Z", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simConn.RegisterDataDefineStruct<Plane>(DATA_STRUCT_ENUM.Plane);

                simConn.RegisterDataDefineStruct<int>(DATA_STRUCT_ENUM.PushbackWait);
                simConn.RegisterDataDefineStruct<int>(DATA_STRUCT_ENUM.TugStatus);

                simConn.RegisterDataDefineStruct<double>(DATA_STRUCT_ENUM.VelocityZ);
                simConn.RegisterDataDefineStruct<double>(DATA_STRUCT_ENUM.RotationX);
                simConn.RegisterDataDefineStruct<double>(DATA_STRUCT_ENUM.RotationY);

                //подключаем различные события сима к переменным
                simConn.MapClientEventToSimEvent(EVENT_ENUM.parkBrakes, "KEY_PARKING_BRAKES");
                simConn.MapClientEventToSimEvent(EVENT_ENUM.tugHeading, "KEY_TUG_HEADING");
                simConn.MapClientEventToSimEvent(EVENT_ENUM.tugDisable, "TUG_DISABLE");
                simConn.MapClientEventToSimEvent(EVENT_ENUM.startPushBack, "TOGGLE_PUSHBACK");

                simConn.MapClientEventToSimEvent(EVENT_ENUM.luggage, "REQUEST_LUGGAGE");
                simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleCatering, "REQUEST_CATERING");
                simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleGroundPower, "REQUEST_POWER_SUPPLY");
                simConn.MapClientEventToSimEvent(EVENT_ENUM.door, "TOGGLE_AIRCRAFT_EXIT");//INOP
                simConn.MapClientEventToSimEvent(EVENT_ENUM.toggleJetway, "TOGGLE_JETWAY");



                simConn.OnRecvSimobjectDataBytype += OnResieveData;
                simConn.OnRecvOpen += SimConn_OnRecvOpen;
                simConn.OnRecvQuit += SimConn_OnRecvQuit;
            }
            catch(Exception ex)
            {
                SimConnectStatus = false;
            }
        }

        private void SimConn_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            SimConnectStatus = false;
        }

        private void SimConn_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            SimConnectStatus = true;
        }

        private void OnResieveData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            //обработка полученных данных от клиента

            if (data.dwRequestID == 0)//самолет
            {
                Plane recData = (Plane)data.dwData[0];
                PlayerControlledAfc = recData;
            }

            if(data.dwRequestID==4)//состояние буксировщика
            {
                var tug = data.dwData[0].ToString();
                PlayerControlledAfc.tugConnStatus = Double.Parse(tug);
                TugConnected = Convert.ToBoolean(PlayerControlledAfc.tugConnStatus);
            }

            ExternalDataUpdate();//данные LVARS
            ParkingBrakesStatus();
        }

        private void ExternalDataUpdate()
        {
            A320brk = DataManager.ReturnValueByKey<double>(A320FBW_BRAKES);
        }

        public void ReceiveMessage()
        {
            simConn.ReceiveMessage();
        }

        public void ReqDataFromSim()
        {
            //непосредсвтенно запрос данных от сима

            if (SimConnectStatus)
            {
                try
                {
                    simConn.RequestDataOnSimObjectType(REQUEST_ENUM.planeReq, DATA_STRUCT_ENUM.Plane, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                    simConn.RequestDataOnSimObjectType(REQUEST_ENUM.worldReq, DATA_STRUCT_ENUM.World, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                    simConn.RequestDataOnSimObjectType(REQUEST_ENUM.doorReq, DATA_STRUCT_ENUM.ExtitType, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                    simConn.RequestDataOnSimObjectType(REQUEST_ENUM.PushbackReq, DATA_STRUCT_ENUM.VelocityZ, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                    simConn.RequestDataOnSimObjectType(REQUEST_ENUM.TugstatusReq, DATA_STRUCT_ENUM.TugStatus, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                }
                catch(Exception ex)
                {

                }
            }
        }

        public void TransmitEventToClient(EVENT_ENUM ev)//передача события в клиент
        {
            simConn.TransmitClientEvent(0U, ev, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        //управление буксировщиком
        public void ConnectTug()//вызов к самолету
        {
            simConn.TransmitClientEvent(0U, EVENT_ENUM.startPushBack, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        public void EmerDiscTUG()//отключение на случай закрытия программы
        {
            if(TugConnected)
            simConn.TransmitClientEvent(0U, EVENT_ENUM.startPushBack, 1, SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        public void UpdateTUG()
        {
            if (SimConnectStatus)
            {
                if (ParkingBrakeStatus)//подключенный буксировщик ожидает, запуск выталкивания вручную
                {
                    simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.PushbackWait, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 1);
                }
                else
                {
                    simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.PushbackWait, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 0);
                    UpdatePB();
                }
            }
        }

        public void StartPushBack()
        {
        }
        public void StopPB()
        {
            tugSpeed = 0;
        }

        private void ParkingBrakesStatus()
        {
            BrakeNotify.Invoke();

            if ((A320brk == 1) || (PlayerControlledAfc.parkingBrake == true))
            {
                ParkingBrakeStatus = true;
                StopPB();
            }
            else
            {
                ParkingBrakeStatus = false;
            }
        }

        public void UpdatePB()
        {

            if (ParkingBrakeStatus)
            {
                StopPB();
            }

            //управление поворотом и скоростью как вперед так и назад с помощью осей rudder и elevator

            tugSpeed += PlayerControlledAfc.elevatorDirection;
            _ = tugSpeed > 0 ? tugSpeed = Math.Min(tugSpeed, MaxTugSdeed) : tugSpeed = Math.Max(tugSpeed, -MaxTugSdeed);

            if (tugSpeed > 0)
            {
                simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(+PlayerControlledAfc.rudderDirection * 90), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }
            else
            {
                simConn.TransmitClientEvent(0U, EVENT_ENUM.tugHeading, SetTugHeading(-PlayerControlledAfc.rudderDirection * 90), SENDER_EVENT_ENUM.group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                //добавлено для того, что когда самолет буксируется в перед, стандартная функция буксировщика хреново его поворачивает, с этим быстрее
                simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.RotationY, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, (double)PlayerControlledAfc.rudderDirection * 0.2);
            }
            simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.VelocityZ, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, (double)-tugSpeed);
            simConn.SetDataOnSimObject(DATA_STRUCT_ENUM.RotationX, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, (double)0);

        }
        private uint SetTugHeading(double angle)
        {
            var hdg = PlayerControlledAfc.heading;
            hdg += angle;
            hdg %= 360;
            hdg = hdg * 11930464;

            return (uint)hdg;

        }

    }
}
