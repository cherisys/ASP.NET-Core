using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App.Mvc.Global
{
    public class GlobalVariables
    {
        public static HttpClient ApiClient = new HttpClient();

        static GlobalVariables()
        {
            ApiClient.BaseAddress = new Uri("http://localhost:32161/api/");
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Add("user-key", "arshad");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
