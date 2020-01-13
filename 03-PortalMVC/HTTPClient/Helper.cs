using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _03_PortalMVC.HTTPClient
{
    public class Helper
    {
        public HttpClient Inicial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63760/");
            return client;

        }
    }
}
