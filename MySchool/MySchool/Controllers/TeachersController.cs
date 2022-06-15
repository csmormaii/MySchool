using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        // GET: api/<TeachersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeachersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private FilmeOutputModel ToOutputModel(Filme model)
        {
            return new FilmeOutputModel
            {
                Id = model.Id,
                Titulo = model.Titulo,
                AnoLancamento = model.AnoLancamento,
                Resumo = model.Resumo,
                UltimoAcesso = DateTime.Now
            };
        }
        private List<FilmeOutputModel> ToOutputModel(List<Filme> model)
        {
            return model.Select(item => ToOutputModel(item)).ToList();
        }
        private Filme ToDomainModel(FilmeInputModel inputModel)
        {
            return new Filme
            {
                Id = inputModel.Id,
                Titulo = inputModel.Titulo,
                AnoLancamento = inputModel.AnoLancamento,
                Resumo = inputModel.Resumo
            };
        }
        private FilmeInputModel ToInputModel(Filme model)
        {
            return new FilmeInputModel
            {
                Id = model.Id,
                Titulo = model.Titulo,
                AnoLancamento = model.AnoLancamento,
                Resumo = model.Resumo
            };
        }
    }
}
