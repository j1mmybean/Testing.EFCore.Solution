﻿using System;
using System.Collections.Generic;

namespace Testing.EFCore.MVC.Model
{
    public partial class TGender
    {
        public TGender()
        {
            TMembers = new HashSet<TMember>();
        }

        public int FGenderId { get; set; }
        public string FGenderType { get; set; } = null!;

        public virtual ICollection<TMember> TMembers { get; set; }
    }
}
