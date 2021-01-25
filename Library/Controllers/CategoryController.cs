using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRepository<Category> repository;

        public CategoryController(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Category> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return repository.GetSingel(id);
        }

        [HttpPost]
        public string Add(Category category)
        {
            repository.Insert(category);
            repository.Save();
            return $"Category Be Esm {category.CategoryName} Afzide Shod";

        }

        [HttpPut]
        public string Update([FromQuery] int id, [FromBody] Category category)
        {
            var find = repository.GetSingel(id);
            find.CategoryName = category.CategoryName;
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
