using Application.InterfaceServices;
using Infrastructure.Interface;
using Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApi.Models;

namespace Application.Services
{
    public class PessoaService :  IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
         
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public bool DeletePessoa(int id)
        {
            return _pessoaRepository.DeletePessoa(id);
        }

        public Task<IEnumerable<Pessoa>> GetListPessoa()
        {
            return _pessoaRepository.GetListPessoa();
        }

        public Task<Pessoa> GetPessoa(int id)
        {
            return _pessoaRepository.GetPessoa(id);
        }

        public bool InsertPessoa(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                ValidatorSys.ValidaTelefone(pessoa.Telefone);
                ValidatorSys.ValidaCpfVazio(pessoa.Cpf);
                ValidatorSys.ValidaEmail(pessoa.Email);
                ValidatorSys.ValidaStringEmpty(pessoa.Nome);
                ValidatorSys.ValidaStringEmpty(pessoa.Nome_Complemento);
            }
            else
                throw new ArgumentException("Validação invalida campos nullos");
            

            return _pessoaRepository.InsertPessoa(pessoa);
        }

        public bool UpdatePessoa(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                ValidatorSys.ValidaTelefone(pessoa.Telefone);
                ValidatorSys.ValidaCpfVazio(pessoa.Cpf);
                ValidatorSys.ValidaEmail(pessoa.Email);
                ValidatorSys.ValidaStringEmpty(pessoa.Nome);
                ValidatorSys.ValidaStringEmpty(pessoa.Nome_Complemento);
            }
            else
                throw new ArgumentException("Validação invalida campos nullos");

            return _pessoaRepository.UpdatePessoa(pessoa);
        }
    }
}
