using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DevFreela.API.Controllers
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Carro> todos()
        {
            List<Carro> carrosDB = new List<Carro>();
            Carro c1 = new Carro { Id = 1, Nome = "L200 Triton" };
            Carro c2 = new Carro { Id = 2, Nome = "L200 Outdoor" };
            Carro c3 = new Carro { Id = 3, Nome = "L200 Savana" };
            Carro c4 = new Carro { Id = 4, Nome = "L200 GL" };
            var lista = new List<Carro>() { c1, c2, c3, c4 };
            carrosDB.AddRange(lista);

            return carrosDB;
        }
    }


    [ApiController]
    [Route("api/rt")]
    public class RTController : ControllerBase
    {
        Carro car = new Carro();

        [HttpGet("teste")]
        public async Task<IActionResult> Teste()
        {
            return Ok(car.todos());
        }

        [HttpGet("teste/{id}")]
        public async Task<IActionResult> ById(int id)
        {
            return Ok(car.todos().Find(x => x.Id == id));
        }
    }
}