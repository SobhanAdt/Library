using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Models
{
    public class CategoryBook : IHasIdetity
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int CategoryId { get; set; }


        #region MyRegion

        public Book Book { get; set; }

        public Category Category { get; set; }

        #endregion
    }
}
