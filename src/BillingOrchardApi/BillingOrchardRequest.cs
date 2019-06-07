using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BillingOrchardApi
{
    public class BillingOrchardRequest
    {
        private const string _apiUrl = "https://billingorchardapi.com/webservice/ChooseService.php";
        internal string Key { get; }
        internal string Service { get; }
        internal const string _hmacKey = "BillingOrchard2012";

        public BillingOrchardRequest(string key, string service)
        {
            Key = key;
            Service = service;
        }

        internal string GenerateHmac()
        {
            string signature = Key + Service + DateTime.UtcNow.ToString("yyyyMMdd HH:mm");
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_hmacKey));
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(signature)));
        }


    }
}
