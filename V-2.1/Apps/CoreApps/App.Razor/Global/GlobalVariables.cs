using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace App.Razor.Global
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
