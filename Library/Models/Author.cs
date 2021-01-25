using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Models
{
    public class Author : IHasIdetity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }


        #region MyRegion

        public List<AuthorBook> AuthorBooks { get; set; }

        #endregion




    }
}
