using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Library.Context;
using Library.DTO;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Components.Web;
using Publisher = Library.Models.Publisher;

namespace Library.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IRepository<Book> repository;
        private IRepository<Author> aRepository;
        private IRepository<CategoryBook> CBepository;
        private IRepository<Category> cRepository;
        private IRepository<Publisher> pRepository;
        private IRepository<AuthorBook> abRepository;

        public BookController(IRepository<Book> repository, IRepository<Author> aRepository,
            IRepository<CategoryBook> cBepository, IRepository<Category> cRepository,
            IRepository<Publisher> pRepository, IRepository<AuthorBook> abRepository)
        {
            this.repository = repository;
            aRepository = aRepository;
            CBepository = cBepository;
            this.cRepository = cRepository;
            this.pRepository = pRepository;
            this.abRepository = abRepository;
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
        public ListSearch Search([FromBody] Search search)
        {
            try
            {
                int publisherId = 0;
                var categoryId = cRepository.GetAll().Where(x => search.categories.Contains(x.CategoryName))
                    .Select(x => x.Id).ToList();

                var authorIds = aRepository.GetAll().Where(x => search.authors.Contains(x.FirstName))
                    .Select(x => x.Id).ToList();

                var publisher = pRepository.GetAll().Where(x => x.PublisherName == search.Publication).FirstOrDefault();
                if (publisher != null)
                {
                    publisherId = publisher.Id;
                }

                var bookId1 = CBepository.GetAll().Where(x => categoryId.Contains(x.CategoryId)).Select(x => x.BookId)
                    .ToList();

                var bookId2 = abRepository.GetAll().Where(x => authorIds.Contains(x.AuthorId)).Select(x => x.BookId)
                    .ToList();

                bookId1.AddRange(bookId2);

                List<Book> books = new List<Book>();
                if (bookId1.Count != 0)
                {
                    books = repository.GetAll().Where(x => bookId1.Contains(x.Id)).ToList();
                }

                if (publisherId != 0)
                {
                    var book1 = repository.GetAll().Where(x => bookId1.Contains(x.Id) && x.PublisherId == publisherId)
                        .ToList();
                }

                if (books.Count != 0)
                {
                    var response = books.Select(x => new SearchResponse()
                    {
                        title = x.BookName,
                        authors = x.AuthorBooks.Select(x => x.Author.FirstName + " " + x.Author.LastName).ToList(),
                        publishDate = x.PublishDate,
                        Publisher = x.Publisher.PublisherName,
                        ISBN = x.ISBN
                    }).ToList();

                    return new ListSearch() { Books = response };
                }

                return null;
            }
            catch 
            {
                throw new Exception("Error");
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
