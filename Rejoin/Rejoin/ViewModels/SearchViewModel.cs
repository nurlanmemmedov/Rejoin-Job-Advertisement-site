using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rejoin.Models;

namespace Rejoin.ViewModels
{
    public class SearchViewModel
    {
        public string KeyWord { get; set; }
        public int CategoryId { get; set; }
        public string Location { get; set; }
    }
}
