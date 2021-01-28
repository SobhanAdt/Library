using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.DTO
{
    public class SearchResponse
    {
        public string title { get; set; }

        public List<string> authors { get; set; }

        public DateTime publishDate { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }
    }

    public class ListSearch
    {
        public List<SearchResponse> Books { get; set; }
    }
}
