using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebMotors.Proxy
{
    public class HttpHelper
    {
        private static string _baseAddress;

        public HttpHelper(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public T GetAsync<T>(string uri)
        {
            HttpResponseMessage response = null;

            using (var client = CreateHttpClient())
            {
                response = client.GetAsync(uri).Result;

                EnsureSuccessStatusCode(response);
            }

            var content = response.Content.ReadAsAsync<T>().Result;

            return content;
        }

        public T PostAsync<T>(string uri, object data)
        {
            HttpResponseMessage response = null;

            using (var client = CreateHttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.PostAsJsonAsync(uri, data).Result;
                EnsureSuccessStatusCode(response);
            }

            var content = response.Content.ReadAsAsync<T>().Result;

            return content;
        }

        private static HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(_baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private static void EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.Content == null)
                    throw new HttpException((int)response.StatusCode, "Ocorreu um erro na comunicação e o sistema não pode concluir a operação.");

                var error = response.Content.ReadAsStringAsync().Result.Trim('[', ']', '"');

                response.Content.Dispose();

                throw new HttpException((int)response.StatusCode, error);
            }
        }
    }
}
