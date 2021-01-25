using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBookController : ControllerBase
    {
        private readonly IRepository<CategoryBook> repository;

        public CategoryBookController(IRepository<CategoryBook> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<CategoryBook> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public CategoryBook Get(int id)
        {
            return repository.GetSingel(id);
        }

        [HttpPost]
        public string Create(CategoryBook categoryBook)
        {
            repository.Insert(categoryBook);
            repository.Save();
            return "Ba Mofaghiyat Insert Shod";

        }

        [HttpPut]
        public string Update([FromQuery] int id, [FromBody] CategoryBook categoryBook)
        {

            var find = repository.GetSingel(id);
            find.BookId = categoryBook.BookId;
            find.CategoryId = categoryBook.CategoryId;
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
