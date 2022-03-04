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
        // private Dictionary<string,double> DataOperation = null;//слвоварь lvar значений <название,значение из lvar> <A32NX_PARK_BRAKE_LEVER_POS,double>
        private Dictionary<string, LvalSelector<object>> DataOperation = null;

        private bool DataResieved = false;

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

            DataOperation = new Dictionary<string, LvalSelector<object>>();
        }

        public void AddDataToDefenition(string data)
        {//добавление данных для обратоки 
            
        }

        public void AddDataToDefenition<T>(T data,string valuename)
        {//добавление данных для обратоки 
            DataOperation.Add(valuename, new LvalSelector<object>(valuename,data));
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
                DataOperation[key] = new LvalSelector<object>(key, lvar.Value);
            }
            DataResieved = true;
        }

        //получаем значение по ключу
        public T ReturnValueByKey<T>(string key)
        {
            if (DataResieved)
            {
                var data = DataOperation[key];
                return (T)data.Value;
            }
            else
            {
                return default(T);
            }
        }
    }
}
