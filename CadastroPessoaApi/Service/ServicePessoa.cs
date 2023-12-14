using CadastroPessoaApi.Data;
using CadastroPessoaApi.ViewModel;

namespace CadastroPessoaApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll();
        }

        public PessoaViewModel GetById(int pessoaID)
        {
            var repository = new Repository();
            return repository.GetById(pessoaID);
        }
        public PessoaViewModel GetByNome(string PrimeiroNome)
        {
            var repository = new Repository();
            return repository.GetByNome(PrimeiroNome);
        }
        public void Update(int pessoaId, string PrimeiroNome)
        {
            if (pessoaId > 0 && !string.IsNullOrEmpty(PrimeiroNome))
            {
                var repository = new Repository();
                repository.Update(pessoaId, PrimeiroNome);
            }

        }
        public string Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatorios";

            if (pessoa != null && string.IsNullOrEmpty(pessoa.NomeMeio))
                return "O campo nomeMeio é obrigatoriro";

            if (pessoa != null && string.IsNullOrEmpty(pessoa.UltimoNome))
                return "O campo UltimoNome é obrigatoriro";

            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "O campo CPF é obrigatoriro";

            var repository = new Repository();
            return repository.Create(pessoa);

        }



    }    



    
}
