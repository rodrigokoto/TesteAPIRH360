using System.Net;
using System.Net.Http.Json;
using TesteApi.Models;

namespace TesteApi_TestProject
{
    public class CasePessoaTeste
    {
        private readonly HttpClient _httpClient;

        public CasePessoaTeste()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async void SelectListPessoa_Sucess()
        {
            var createResponse = await _httpClient.GetFromJsonAsync<List<Pessoa>>("https://localhost:7091/api/Pessoa");

            Assert.NotNull(createResponse);
            Assert.True(createResponse.Count > 0);

        }

        [Fact]
        public async void SelectPessoa_Sucess() {

            var createResponse = await  _httpClient.GetFromJsonAsync<Pessoa>("https://localhost:7091/api/Pessoa/2");

            Assert.NotNull(createResponse);
        }
    }
}