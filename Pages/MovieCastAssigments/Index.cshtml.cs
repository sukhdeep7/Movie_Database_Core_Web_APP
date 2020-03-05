using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie_Database_Core_Web_APP.BusinessLayer;
using Movie_Database_Core_Web_APP.Models;

namespace Movie_Database_Core_Web_APP.Pages.MovieCastAssigments
{
    //Gets all movie casts using a linq query
    public class IndexModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public IndexModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Movie cast list
        public IList<MovieCastAssignment> MovieCastAssignment { get;set; }

        //Gets the Movie casts list using a lamda query
        public void  OnGet()
        {
            MovieCastAssignment = _context.MovieCastAssignment
                .Include(m => m.Actor)
                .Include(m => m.Movie).ToList();
        }
    }
}
