using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IRepository<Author> repository;

        public AuthorController(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Author> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return repository.GetSingel(id);
        }

        [HttpPost]
        public string Create([FromBody] Author author)
        {

            repository.Insert(author);
            repository.Save();
            return $"Ba Mofaghiyat Shakhs {author.LastName} Insert Shod";
        }

        [HttpPut]
        public string Update([FromQuery] int id, [FromBody] Author author)
        {
            var find = repository.GetSingel(id);
            find.Age = author.Age;
            find.FirstName = author.FirstName;
            find.LastName = author.LastName;
            repository.Update(find);
            repository.Save();
            return "Update Ba Mofaghiyat Anjam Shod";
        }

        [HttpDelete]
        public string Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return "Delete Ba Mofaghiyat Anjam Shod";
        }
    }
}
