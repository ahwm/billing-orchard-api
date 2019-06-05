using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BillingOrchardApi
{
    public class BillingOrchardRequest
    {
        internal string _key { get; }
        internal string _service { get; }
        internal const string _hmacKey = "BillingOrchard2012";

        public BillingOrchardRequest(string key, string service)
        {
            _key = key;
            _service = service;
        }

        internal string GenerateHmac()
        {
            string signature = _key + _service + DateTime.UtcNow.ToString("yyyyMMdd HH:mm");
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_hmacKey));
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(signature)));
        }


    }
}
