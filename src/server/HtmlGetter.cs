using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RapidCore.Network;

namespace GeneRicIdp.Server
{
    public class HtmlGetter
    {
        private readonly IRapidHttpClient client;

        public HtmlGetter(IRapidHttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetPickProviderHtmlAsync(string url, LoginViewModel viewModel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
            
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"{response.StatusCode}: {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}