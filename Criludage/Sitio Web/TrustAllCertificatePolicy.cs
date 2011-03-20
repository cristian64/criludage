using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace Sitio_Web
{
    public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    {
        public TrustAllCertificatePolicy() { }
        public bool CheckValidationResult(ServicePoint sp,
            System.Security.Cryptography.X509Certificates.X509Certificate cert,
            WebRequest req,
            int problem)
        {
            return true;
        }
    }
}