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
    public class AuthorBookController : ControllerBase
    {
        private readonly IRepository<AuthorBook> repository;

        public AuthorBookController(IRepository<AuthorBook> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<AuthorBook> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public AuthorBook Get(int id)
        {
            return repository.GetSingel(id);
        }

        [HttpPost]
        public string Create([FromBody] AuthorBook authorBook)
        {
            repository.Insert(authorBook);
            repository.Save();
            return "Insert Shod";
        }

        [HttpPut]
        public string Update([FromQuery] int id, [FromBody] AuthorBook authorBook)
        {
            var find = repository.GetSingel(id);
            find.AuthorId = authorBook.AuthorId;
            find.BookId = authorBook.BookId;
            repository.Update(find);
            repository.Save();
            return "Update Ba Mofaghiyat Anjam Shod";
        }

        [HttpDelete]
        public string Delete([FromQuery] int id)
        {
            repository.Delete(id);
            return "Delete Ba Mofaghiyat Anjam Shod";
        }
    }
}
