using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.Exeptions
{
    public class OnlineBazarExeption : Exception
    {
        public int Code { get; set; }
        public OnlineBazarExeption(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
