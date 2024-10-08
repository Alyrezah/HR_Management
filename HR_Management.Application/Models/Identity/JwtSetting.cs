﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Models.Identity
{
    public class JwtSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
