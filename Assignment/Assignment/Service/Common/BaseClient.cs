using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Assignment.Service.Common
{
    public class BaseClient
    {
        protected HttpClient GetHttpClient()
        {
            HttpClient client;
            
            client = new HttpClient();
           
            return client;
        }
    }
}
