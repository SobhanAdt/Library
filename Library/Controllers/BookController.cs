using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Library.Context;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IRepository<Book> repository;


        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Book> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return repository.GetSingel(id);
        }

        [HttpPost]
        public string Create([FromBody] Book book)
        {

            repository.Insert(book);
            repository.Save();
            return $"Booki Be Esm {book.BookName} Afzide Shod";

        }

        //[HttpPost("{search}")]
        //public Search Search([FromBody] Search search)
        //{
        //    return search;
        //}

        [HttpPut]
        public string Update([FromQuery] int id, [FromBody] Book book)
        {

            var find = repository.GetSingel(id);
            find.BookName = book.BookName;
            find.Bookcode = book.Bookcode;
            find.PublisherId = book.PublisherId;
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
