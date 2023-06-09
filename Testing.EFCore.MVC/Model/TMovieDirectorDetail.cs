﻿using System;
using System.Collections.Generic;

namespace Testing.EFCore.MVC.Model
{
    public partial class TMovieDirectorDetail
    {
        public int FSerialNumber { get; set; }
        public int FDirectorId { get; set; }
        public int FMovieId { get; set; }

        public virtual TDirector FDirector { get; set; } = null!;
        public virtual TMovie FMovie { get; set; } = null!;
    }
}
