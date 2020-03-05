using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie_Database_Core_Web_APP.BusinessLayer;
using Movie_Database_Core_Web_APP.Models;

namespace Movie_Database_Core_Web_APP.Pages.Movies
{
    //Delets the movie 
    public class DeleteModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public DeleteModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Binds the movie model.
        [BindProperty]
        public Movie Movie { get; set; }

        //gets the movie for delete using a lamda query
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie =  _context.Movie
                .Include(m => m.Director).FirstOrDefault(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the movie uses a linq query to select the movie
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = (from movie in _context.Movie
                     where movie.Id == id
                     select movie).FirstOrDefault();



            if (Movie != null)
            {
                _context.Movie.Remove(Movie);
               _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
