using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model
{
    public class ReturnData<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Obj{get;set;}
        public ReturnData()
        {
            Success = true;
        }
    }
}
