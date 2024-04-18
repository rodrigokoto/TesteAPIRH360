using Application.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Models;

namespace TesteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        /// <summary>
        /// Retorna a Pessoa por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}", Name = "GetPessoa")]
        public  async Task<ActionResult<Pessoa>> GetPessoa(int Id) 
        {
            var pessoa  = await _pessoaService.GetPessoa(Id);

            if(pessoa == null)
            {
                return NotFound();
            }
            else return Ok(pessoa);
        }
        /// <summary>
        /// Retorna Lista de Pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPessoas")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var pessoas = await _pessoaService.GetListPessoa();
            return Ok(pessoas);
        }

        /// <summary>
        /// Inserir Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreatePessoa")]
        public async Task<ActionResult<int>> CreatePessoa(Pessoa pessoa)
        {
            var result =  _pessoaService.InsertPessoa(pessoa);
            if (!result)
                return NotFound("Erro ao inserir Pessoa");

            return Ok("Pessoa inserida com sucesso!");

        }
        /// <summary>
        /// Atualizar Pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdatePessoa")]
        public async Task<IActionResult> UpdatePessoa(Pessoa pessoa)
        {
            var result =  _pessoaService.UpdatePessoa(pessoa);
            if (!result)
                return NotFound("Erro ao alterar pessoa");

            return Ok("Pessoa Alterada com sucesso!");
        }

        /// <summary>
        /// Deletar Pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}" , Name = "DeletePessoa")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var result =  _pessoaService.DeletePessoa(id);
            if (!result)
                return NotFound("Erro ao deletar Pessoa");

            return Ok("Pessoa Excluida com sucesso!");
        }
    }
}
