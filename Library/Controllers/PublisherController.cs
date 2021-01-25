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
    public class PublisherController : ControllerBase
    {
        private readonly IRepository<Publisher> repository;

        public PublisherController(IRepository<Publisher> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Publisher> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Publisher Get(int id)
        {
            return repository.GetSingel(id);
        }

        [HttpPost]
        public string Create(Publisher publisher)
        {

            repository.Insert(publisher);
            repository.Save();
            return "Ba Mofaghiyat Insert Shod";


        }

        [HttpPut]
        public string Update([FromQuery] int id, [FromBody] Publisher publisher)
        {
            var find = repository.GetSingel(id);
            find.PublisherName = publisher.PublisherName;
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
