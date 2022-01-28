using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSAssistant.Services
{
    //все структуры и enums для работы с данными через FSUIPC;

    //самолет с набором необходимых значений
    public struct Plane
    {
        public double heading;
        public double altitude;
        public double speed;
        public double eta;
        public double ete;

        public double rudderDirection;
        public double elevatorDirection;
        public bool parkingBrake;
        public double tugConnStatus;

        public double A320FBWBrakes;
    }

    //группа отправки данных
    public enum SENDER_EVENT_ENUM
    {
        group0
    }

    //список событий отправляемых в сим
    public enum EVENT_ENUM
    {
        toggleJetway,
        toggleGroundPower,
        toggleCatering,
        startPushBack,
        tugSpeed,
        tugHeading,
        luggage,
        door,
        tugDisable,
        parkBrakes
    }

    //группы запросов данных от сима
    public enum REQUEST_ENUM
    {
        planeReq,
        worldReq,
        doorReq,
        PushbackReq,
        TugstatusReq

    }
    //дата структуры запроса
    public enum DATA_STRUCT_ENUM
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

   

}
