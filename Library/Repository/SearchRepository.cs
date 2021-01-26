using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;

namespace Library.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private List<Search> listSearch = new List<Search>();
        public ListSearch GetAllSerach()
        {
            throw new NotImplementedException();
        }

        public void Insert(Search search)
        {
            try
            {
                listSearch.Add(search);
            }
            catch
            {
                throw new Exception("Error Search");
            }
        }
    }
}
