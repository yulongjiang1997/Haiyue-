using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Model
{
    public class NoteBook:BaseModel
    {
        public BgColorType BgColor { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
