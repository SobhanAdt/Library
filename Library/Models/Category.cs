using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Models
{
    public class Category : IHasIdetity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        #region MyRegion

        public List<CategoryBook> CategoryBooks { get; set; }

        #endregion


    }
}
