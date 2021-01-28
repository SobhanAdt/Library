using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Search
    {
       
        public List<string> authors { get; set; }

        
        public List<string> categories { get; set; }

        
        public string Publication { get; set; }
    }

   
}
