using System;
using System.Collections.Generic;
using System.Text;

namespace BillingOrchardApi
{
    public class BillingOrchard
    {
        private readonly BillingOrchardRequest _request;
        public BillingOrchard(BillingOrchardRequest request)
        {
            _request = request;
        }
    }
}
