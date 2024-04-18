using Application.InterfaceServices;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using TesteApi.Models;

namespace TestApi_Test
{
    public class TestePessoa
    {
        private readonly IPessoaService _pessoaService;

        public TestePessoa()
        {
            var serviceProvider = new ServiceCollection().AddScoped<IPessoaService , PessoaService>().BuildServiceProvider();  

            _pessoaService = serviceProvider.GetRequiredService<IPessoaService>();
        }

        [Fact]
        public void InserPessoa_Sucesso()
        {
            var pessoa = new Pessoa
            {
                Nome = "Teste",
                Nome_Complemento = "Sucesso",
                Rg = "33.333.333-3",
                Cpf = "123.456.789-00",
                Email = "joao@example.com",
                Telefone = "11 23456789",
                Id_Anexo_Sys = 1,
                Data_Alteracao = DateTime.Now,
                Data_Cadastro = DateTime.Now
            };


            var result = _pessoaService.InsertPessoa(pessoa);
            Assert.True(result);

        }
    }
}