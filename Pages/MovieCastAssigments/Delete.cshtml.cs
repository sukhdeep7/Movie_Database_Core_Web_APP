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

    //Deletes the movie cast assigment.
    public class DeleteModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public DeleteModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Binds the movie cast 
        [BindProperty]
        public MovieCastAssignment MovieCastAssignment { get; set; }

        //Gets the Movie cast for delete using a lamda query.
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

        //Deletes the movie cast from the databse. Uses a linq query to 
        //select the movie cast 
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieCastAssignment = (from moviecasts in _context.MovieCastAssignment
                                   where moviecasts.Id == id
                                   select moviecasts).FirstOrDefault();

            if (MovieCastAssignment != null)
            {
                _context.MovieCastAssignment.Remove(MovieCastAssignment);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
