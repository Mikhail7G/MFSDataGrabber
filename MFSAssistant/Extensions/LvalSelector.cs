using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSAssistant.Extensions
{
    //хранилище Lvar значений от сима
    public class LvalSelector<T>
    {
        public string VariableName { set; get; }
        public T Value { set; get; }

        public LvalSelector(string Name, T obj)
        {
            VariableName = Name;
            Value = obj;
        }
    }
}
