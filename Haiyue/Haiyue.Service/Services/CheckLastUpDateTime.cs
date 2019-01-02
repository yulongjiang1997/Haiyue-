using Haiyue.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Service.Services
{
    public static class CheckLastUpDateTime
    {
        public static ReturnData<bool> Check(DateTime modelTime,DateTime dataBaseTime)
        {
            var result = new ReturnData<bool>();
            if (modelTime != dataBaseTime)
            {
                result.Message = "操作超时，请刷新页面";
                result.Obj = false;
                result.Success = false;
            }
            return result;
        }
    }
}
