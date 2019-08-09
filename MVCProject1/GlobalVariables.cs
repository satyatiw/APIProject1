using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVCProject1
{
    public static class GlobalVariables
    {
        public static HttpClient WebAPIClient = new HttpClient();

        static   GlobalVariables()
        {
            WebAPIClient.BaseAddress = new Uri("http://localhost:59041/api/");
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
        }
    }
}
