using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using FSUIPC;

namespace MFSDataGrabber.ExternalData
{
    public class ExternalDataManager
    {
        private MSFSVariableServices ExternalServise = null;
        private FsLVar LvarListener = null;
        private bool started = false;
        public double A320BrakeStatus { get; set; }

        private string A320FBWBrake = "A32NX_PARK_BRAKE_LEVER_POS";

        public  ExternalDataManager(IntPtr _handle)
        {
            InitExternalService(_handle);
        }
        public void InitExternalService(IntPtr _handle)
        {
            ExternalServise = new MSFSVariableServices();
            ExternalServise.OnValuesChanged += ExternalServise_OnValuesChanged;
            ExternalServise.Init(_handle);
            ExternalServise.LVARUpdateFrequency = 10;
            ExternalServise.Start();
            ExternalServise.LogLVars();


        }

        public void UpdateRealTime()
        {
            FsLVar lvar = ExternalServise.LVars[A320FBWBrake];
            if (lvar != null)
                A320BrakeStatus=lvar.Value;


        }

        private void ExternalServise_OnValuesChanged(object sender, EventArgs e)
        {
            UpdateRealTime();   
        }
    }
}
