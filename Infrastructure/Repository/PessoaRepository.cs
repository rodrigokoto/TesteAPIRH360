using Dapper;
using Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using TesteApi.Models;

namespace Infrastructure.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IDbConnection _dbConnection;

        public PessoaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool DeletePessoa(int id)
        {

            string query = @"Delete 
                            FROM Pessoa
                            WHERE id = @Id";
            var rowsDeleted =  _dbConnection.Execute(query, new { Id = id });
            return rowsDeleted > 0;
        }

        Task<IEnumerable<Pessoa>> IPessoaRepository.GetListPessoa()
        {
            string query = @"SELECT id, nome, nome_complemento, rg, cpf, email, telefone, id_anexo_sys, data_alteracao, data_cadastro 
                             FROM pessoa";
            return  _dbConnection.QueryAsync<Pessoa>(query);
        }

        Task<Pessoa> IPessoaRepository.GetPessoa(int id)
        {
            string query = @"SELECT id, nome, nome_complemento, rg, cpf, email, telefone, id_anexo_sys, data_alteracao, data_cadastro 
                             FROM pessoa 
                             WHERE id = @Id";
            return _dbConnection.QueryFirstOrDefaultAsync<Pessoa>(query , new { Id = id});
        }

        public bool UpdatePessoa(Pessoa pessoa)
        {
            string query = @"UPDATE pessoa SET
                             nome = @Nome,
                             nome_complemento = @Nome_Complemento, 
                             rg = @Rg, 
                             cpf = @Cpf, 
                             email = @Email, 
                             telefone = @Telefone, 
                             id_anexo_sys = @Id_Anexo_Sys , 
                             data_alteracao = CURRENT_TIMESTAMP 
                             WHERE id = @Id";

            try
            {
                _dbConnection.Open();

                var InsertedRows = _dbConnection.Execute(query, new {pessoa.Nome, pessoa.Nome_Complemento, pessoa.Rg, pessoa.Cpf, pessoa.Email, pessoa.Telefone, pessoa.Id_Anexo_Sys, pessoa.Data_Alteracao, pessoa.Data_Cadastro, pessoa.Id });
                return InsertedRows > 0;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao inserir: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

        public bool InsertPessoa(Pessoa pessoa)
        {
            string query = @$"INSERT INTO pessoa(Nome, nome_complemento, rg, cpf, email, telefone, id_anexo_sys, data_alteracao, data_cadastro)
                             VALUES (@Nome, @Nome_Complemento, @Rg, @Cpf, @Email, @Telefone, @Id_anexo_sys, @Data_alteracao, @Data_cadastro)";

            try
            {
                _dbConnection.Open();
               
                var InsertedRows = _dbConnection.Execute(query, new { pessoa.Nome , pessoa.Nome_Complemento , pessoa.Rg , pessoa.Cpf , pessoa.Email , pessoa.Telefone , pessoa.Id_Anexo_Sys , pessoa.Data_Alteracao , pessoa.Data_Cadastro  });
                return InsertedRows > 0;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao inserir: {ex.Message}");
            }
            finally 
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
           
        }
    }
}
