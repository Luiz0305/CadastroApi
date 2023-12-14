using CadastroPessoaApi.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace CadastroPessoaApi.Data
{
    public class Repository
    {
        string Conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "SELECT TOP 1000 * FROM PESSOAS";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }
        }
        public PessoaViewModel GetById(int pessoaId)
        {
            string query = "SELECT * FROM PESSOAS WHERE pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId });
            }
        }
        public PessoaViewModel GetByNome(string PrimeiroNome)
        {
            string query = "SELECT * FROM PESSOAS WHERE PrimeiroNome = @PrimeiroNome";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { PrimeiroNome = PrimeiroNome });
            }
        }
        public void Update(int pessoaId, string PrimeiroNome)
        {
            string query = "Update PESSOAS set PrimeiroNome = @PrimeiroNome where  pessoaId = @pessoaId ";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                con.Execute(query, new { pessoaId = pessoaId, PrimeiroNome = PrimeiroNome });
            }
        }

        public string Create(PessoaViewModel pessoa)
        {



            string query = @"
                    Insert into PESSOAS (PrimeiroNome, NomeMeio, UltimoNome, CPF)
                    values (@PrimeiroNome, @NomeMeio, @UltimoNome, @CPF)";
                using (SqlConnection con = new SqlConnection(Conexao))
                {
                    con.Execute(query, new
                    {
                        PrimeiroNome = pessoa.PrimeiroNome,
                        NomeMeio = pessoa.NomeMeio,
                        CPF = pessoa.CPF,
                        UltimoNome = pessoa.UltimoNome,
                    });


                }
                return null;

            

        }
    }
}
