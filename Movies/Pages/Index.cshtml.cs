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
        [BindProperty]
        public string search { get; set; }
        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();
        [BindProperty]
        public float? minIMDB { get; set; }
        public void OnGet()
        {
            movies = MovieDatabase.All;
        }
        
        public void OnPost()
        {
            if(search != null && mpaa.Count > 0)
            {
                movies = MovieDatabase.Search(search);
                movies = MovieDatabase.FilterByMPAA(movies, mpaa);

            }
            else if (search != null)
            {
                movies = MovieDatabase.Search(search);
            }
            else if(mpaa.Count > 0)
            {
                movies = MovieDatabase.FilterByMPAA(MovieDatabase.All, mpaa);
            }
            else
            {
                movies = MovieDatabase.All;
            }

            if(minIMDB is float min)
            {
                movies = MovieDatabase.FilterByMinIMDB(movies, min);
            }
        }
    }
}
