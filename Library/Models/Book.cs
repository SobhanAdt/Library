using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Models
{
    public class Book:IHasIdetity
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public int Bookcode { get; set; }

        public int PublisherId { get; set; }

        

        #region Relation

        public List<CategoryBook> CategoryBooks { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; }

        public Publisher Publisher { get; set; }

        #endregion



    }
}
