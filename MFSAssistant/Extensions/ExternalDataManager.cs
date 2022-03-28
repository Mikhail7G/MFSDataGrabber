using System;
using System.Collections.Generic;
using System.Linq;
using FSUIPC;


namespace MFSAssistant.Extensions
{

    /// <summary>
    /// Класс работы с данными, непокрываемые simConnect. Используется FSIUPC и WASM
    /// </summary>
    public partial class ExternalDataManager
    {
        private MSFSVariableServices externalService = null;
        private Dictionary<string, LvalSelector<object>> dataOperation = null;

        private bool dataResieved = false;//Нужно так как обновление данных происходит позже, чем первый запрос от сима.

        public ExternalDataManager(IntPtr handle)
        {
            InitExternalService(handle);
        }

        private void InitExternalService(IntPtr handle)
        {//инициализируем библиотеку и начальные параметры
            externalService = new MSFSVariableServices();
            externalService.OnValuesChanged += ExternalServiсe_OnValuesChanged;
            externalService.Init(handle);
            externalService.LVARUpdateFrequency = 10;
            externalService.Start();
            externalService.LogLVars();

            dataOperation = new Dictionary<string, LvalSelector<object>>();
        }

        public void AddDataToDefenition(string data)
        {
            //INOP  
        }

        public void AddDataToDefenition<T>(T dataType, string valuename)
        {//добавление данных для обратоки 
            dataOperation.Add(valuename, new LvalSelector<object>(valuename,dataType));
        }

        private void ExternalServiсe_OnValuesChanged(object sender, EventArgs e)
        {//при изменении значений получаем измененные данные
            UpdateRealTime();
        }

        public void UpdateRealTime()
        {//обрабатываем все и запихиваем в словарь
            foreach(var data in dataOperation.ToList())
            {
                FsLVar lvar = externalService.LVars[data.Key];
                string key = data.Key;
                if (lvar != null)
                dataOperation[key] = new LvalSelector<object>(key, lvar.Value);
            }
            dataResieved = true;
        }

        //получаем значение по ключу
        public T ReturnValueByKey<T>(string key)
        {
            if (dataResieved)
            {
                var data = dataOperation[key];
                return (T)data.Value;
            }
            else
            {
                return default(T);
            }
        }
    }
}
