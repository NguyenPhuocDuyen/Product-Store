using System;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Utility
{
    public static class GobalVariables
    {
        private static readonly HttpClient httpClient = new();
        public static HttpClient WebAPIClient = httpClient;

        static GobalVariables()
        {
            WebAPIClient.BaseAddress = new Uri("https://localhost:44364/api/apigateway/"); // service api gateway
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void AddAuthorizationHeader(this HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
