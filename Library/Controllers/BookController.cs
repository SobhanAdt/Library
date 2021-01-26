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
        private IRepository<Author> aRepository;
        private IRepository<CategoryBook> cRepository;

        public BookController(IRepository<Book> repository, IRepository<Author> aRepository, IRepository<CategoryBook> cRepository)
        {
            this.repository = repository;
            this.aRepository = aRepository;
            this.cRepository = cRepository;
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

        [HttpPost("{search}")]
        public void Search([FromBody] Search search)
        {

            //for (int i = 0; i < search.authors.Count; i++)
            //{
            //    var x1 = aRepository.GetAll().Where(x => x.LastName == search.authors[i]);
            //}

            //var x2 = repository.GetAll().Where(x => x.Publisher.PublisherName == search.Publication);

            //for (int i = 0; i < search.categories.Count; i++)
            //{
            //    var x3 = cRepository.GetAll().Where(x => x.CategoryName == search.categories[i]);
            //}

            //return x2.ToString();

            try
            {
                var response = cRepository.GetAll()
                    .Where(x => search.categories.Contains(x.Book.BookName)).Select(x => new
                    {
                        title = x.Book.BookName,
                        pulishdate = x.Book.PublishDate,
                        publisher = x.Book.Publisher.PublisherName,
                        ISBN = x.Book.ISBN,
                        author = x.Book.AuthorBooks.Select(x => x.Author.FirstName + " " + x.Author.LastName)
                    }).ToList();
            }
            catch
            {
                throw new Exception("Error Search");
            }

        }

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
