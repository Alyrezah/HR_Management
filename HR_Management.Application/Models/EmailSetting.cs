﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Models
{
    public class EmailSetting
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string SenderName { get; set; }
    }
}
