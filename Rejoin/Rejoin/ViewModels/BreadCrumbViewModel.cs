using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.ViewModels
{
    public class BreadCrumbViewModel
    {
        public string Title { get; set; }
        public Dictionary<string, List<string>> Parents { get; set; }
    }
}
