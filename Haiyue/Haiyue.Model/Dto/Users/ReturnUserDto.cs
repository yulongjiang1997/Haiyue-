using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Users
{
    public class ReturnUserDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public JurisdictionType Jurisdiction { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 户口
        /// </summary>
        public string RegisteredResidence { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public EducationType Education { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        public IncumbencyStatusType IncumbencyStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LoginTime { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastUpDateTime { get; set; }
    }
}
