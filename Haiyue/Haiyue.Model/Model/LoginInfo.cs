using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class LoginInfo : BaseModel<int>
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Token { get; set; }

        public DateTime OutTime { get; set; }
    }
}
