﻿using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.NoteBooks
{
    public class NoteBookAddOrEditDto
    {
        public BgColorType BgColor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}