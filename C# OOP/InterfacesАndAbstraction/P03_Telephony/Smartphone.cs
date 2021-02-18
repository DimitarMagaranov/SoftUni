using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Telephony
{
    public class Smartphone : IBrowsing
    {
        public string Browsing(string site)
        {
            return $"Browsing: {site}!";
        }

        public string Calling(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }
    }
}
