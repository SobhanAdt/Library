using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Models
{
    public class AuthorBook : IHasIdetity
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int BookId { get; set; }



        #region Relation

        public Book Book { get; set; }

        public Author Author { get; set; }

        #endregion

    }
}
