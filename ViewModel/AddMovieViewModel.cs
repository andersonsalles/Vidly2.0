using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class AddMovieViewModel
    {
        public string PageName { get; set; }
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}