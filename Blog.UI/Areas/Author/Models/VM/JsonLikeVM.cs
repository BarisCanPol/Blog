﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.UI.Areas.Author.Models.VM
{
    public class JsonLikeVM
    {
        public string UserMessage { get; set; }
        public int Likes { get; set; }
        public bool isSuccess { get; set; }

    }
}