﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Helpers {
    public class SmtpSettings {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username {get;set;}
        public string Password { get; set; }
    }
}
