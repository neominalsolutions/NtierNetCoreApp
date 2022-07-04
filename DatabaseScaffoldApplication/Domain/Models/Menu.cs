using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Domain.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string MenuIcon { get; set; }

    }
}
