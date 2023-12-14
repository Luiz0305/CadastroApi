using CadastroPessoaApi.Service;
using CadastroPessoaApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();
        }
        [HttpGet("GetById/{pessoaID}")]
        public PessoaViewModel GetById(int pessoaID)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaID);
        }
        [HttpGet("GetByNome/{PrimeiroNome}")]
        public PessoaViewModel GetByNome(string PrimeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByNome(PrimeiroNome);
        }
        [HttpPut("Update/{pessoaId}/{PrimeiroNome}")]
        public void Update(int pessoaId, string PrimeiroNome)
        {
            var service = new ServicePessoa();
            service.Update(pessoaId, PrimeiroNome);

        }
        [HttpPost("Create")]
        public ActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            if (resultado == null)
            {
                var result = new
                {
                    Sucess = true,
                    Data = "Cadastro com Sucesso",
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    Sucess = false,
                    Data = resultado,
                };
                return Ok(result);
            }

        }
        [HttpDelete("Delete")]

        public ActionResult Delete(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Delete(pessoa);

            if (resultado == null)
            {
                var result = new
                {
                    Sucess = true,
                    Data = "Deletado com Sucesso",
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    Sucess = false,
                    Data = resultado,
                };
                return Ok(result);
            }
        }

    }
}
