using System.Threading.Tasks;
using TesteApi.Models;

namespace Infrastructure.Interface
{
    public interface IPessoaRepository
    {
        public Task<Pessoa> GetPessoa(int id);
        public Task<IEnumerable<Pessoa>> GetListPessoa();
        public bool DeletePessoa(int id);
        public bool UpdatePessoa(Pessoa pessoa);
        public bool InsertPessoa(Pessoa pessoa);
    }
}
