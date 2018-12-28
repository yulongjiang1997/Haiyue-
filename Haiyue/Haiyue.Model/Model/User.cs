using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class User : BaseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWored { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public JurisdictionType Jurisdiction { get; set; }

        /// <summary>
        /// 职位外键ID
        /// </summary>
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

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
        

        public ICollection<Expenditure> Expenditures { get; set; }
    }
}
