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
    //Details of the Movie cast.
    public class DetailsModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public DetailsModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Holds the movie cast model.
        public MovieCastAssignment MovieCastAssignment { get; set; }

        //gets the movie cast using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieCastAssignment =  _context.MovieCastAssignment
                .Include(m => m.Actor)
                .Include(m => m.Movie).FirstOrDefault(m => m.Id == id);

            if (MovieCastAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
