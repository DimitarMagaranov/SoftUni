﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Telephony
{
    public interface IBrowsing : ICalling
    {
        string Browsing(string site);
    }
}
