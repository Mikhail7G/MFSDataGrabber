using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSAssistant.Extensions
{
    //Список получаемых LVARS
    public partial class ExternalDataManager
    {
        public double GetA320FBWBrakeStatus()
        {//возвращаем данные о состоянии тормоза у FBW
            double result = 0;
            result = DataOperation["A32NX_PARK_BRAKE_LEVER_POS"];

            return result;
        }

        public double GetA320FBWSpoilers()
        {//возвращаем данные о состоянии тормоза у FBW
            double result = 0;
            result = DataOperation["A32NX_SPOILERS_ARMED"];

            return result;
        }
    }

}
