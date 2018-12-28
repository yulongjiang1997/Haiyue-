using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Enums
{
    public enum TaskStatusType
    {
        /// <summary>
        /// 待处理
        /// </summary>
        ToBeProcessed,
        
        /// <summary>
        /// 进行中
        /// </summary>
        Processing,
        
        /// <summary>
        /// 已完成
        /// </summary>
        Completed,

        /// <summary>
        /// 已取消
        /// </summary>
        Cancelled,
    }
}
