using Newtonsoft.Json.Linq;
using ApiVendas.Models;

namespace ApiVendas.Services
{
    public class ApiService
    {
        public readonly IHttpClientFactory _IhttpClientFactory;

        public ApiService(IHttpClientFactory Ihttpclient)
        {
            _IhttpClientFactory = Ihttpclient;
        }


        public async Task<string> GetApi(string cpnj)
        {
            Console.WriteLine(cpnj);
            var httpclient =  _IhttpClientFactory.CreateClient("apicnpj");
            var URL = $"cnpj/{cpnj}";
            var response = await httpclient.GetAsync(URL);

            //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<OportunidadeModels>(v_razao); */
            return await response.Content.ReadAsStringAsync();



        }

    }
}
