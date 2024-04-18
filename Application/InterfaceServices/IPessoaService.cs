using TesteApi.Models;

namespace Application.InterfaceServices
{
	public interface IPessoaService 
	{
        public Task<Pessoa> GetPessoa(int id);
        public Task<IEnumerable<Pessoa>> GetListPessoa();
        public bool DeletePessoa(int id);
        public bool UpdatePessoa(Pessoa pessoa);
        public bool InsertPessoa(Pessoa pessoa);

    }
}
