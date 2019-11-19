using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        public MovieDatabase MovieDatabase = new MovieDatabase();
        public List<Movie> movies = new List<Movie>();
        public void OnGet()
        {
            movies = MovieDatabase.All;
        }

        public void OnPost(string search)
        {
            movies = MovieDatabase.Search(search);
        }
    }
}
