using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Admin
{
    public class ReturnLoginDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public JurisdictionType Jurisdiction { get; set; }

        public string Token { get; set; }

        public DateTime OutTime { get; set; }
    }
}
