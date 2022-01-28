using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;
using MFSAssistant.Services;

namespace MFSAssistant.Extensions
{

    //Класс работы с данными, непокрываемые simConnect. Используется FSUIPC и WASM
    //partial - вынес получение данных в другой файл для наглядности
    public partial class ExternalDataManager
    {
        private MSFSVariableServices ExternalService = null;
        private Dictionary<string,double> DataOperation = null;//слвоварь lvar значений <название,значение из lvar> <A32NX_PARK_BRAKE_LEVER_POS,double>

        public ExternalDataManager(IntPtr handle)
        {
            InitExternalService(handle);
        }

        private void InitExternalService(IntPtr handle)
        {//инициализируем библиотеку и начальные параметры
            ExternalService = new MSFSVariableServices();
            ExternalService.OnValuesChanged += ExternalServiсe_OnValuesChanged;
            ExternalService.Init(handle);
            ExternalService.LVARUpdateFrequency = 10;
            ExternalService.Start();
            ExternalService.LogLVars();

            DataOperation = new Dictionary<string, double>();
        }

        public void AddDataToDefenition(string data)
        {//добавление данных для обратоки 
            DataOperation.Add(data, 0);
        }

        private void ExternalServiсe_OnValuesChanged(object sender, EventArgs e)
        {//при изменении значений получаем измененные данные
            UpdateRealTime();
        }

        public void UpdateRealTime()
        {//обрабатываем все и запихиваем в словарь
            foreach(var data in DataOperation.ToList())
            {
                FsLVar lvar = ExternalService.LVars[data.Key];
                string key = data.Key;
                if (lvar != null)
                    DataOperation[key] = lvar.Value;

            }
        }
    }
}
