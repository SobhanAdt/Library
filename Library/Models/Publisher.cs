using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Models
{
    public class Publisher : IHasIdetity
    {
        public int Id { get; set; }

        public string PublisherName { get; set; }


        #region MyRegion

        public List<Book> Books { get; set; }

        #endregion

    }
}
