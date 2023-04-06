﻿using System;
using System.Collections.Generic;

namespace Testing.EFCore.MVC.Model
{
    public partial class TArticleKeywordDetail
    {
        public int FSerialNumber { get; set; }
        public int FArticleId { get; set; }
        public int FKeywordId { get; set; }

        public virtual TArticle FArticle { get; set; } = null!;
        public virtual TKeyword FKeyword { get; set; } = null!;
    }
}
