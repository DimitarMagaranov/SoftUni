using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Telephony
{
    public class StationeryPhone : ICalling
    {
        public string Calling(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
