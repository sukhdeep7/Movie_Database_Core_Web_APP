using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Database_Core_Web_APP.BusinessLayer;
using Movie_Database_Core_Web_APP.Models;

namespace Movie_Database_Core_Web_APP.Pages.MovieCastAssigments
{
    //Update the Movie cast 
    public class EditModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public EditModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Binds the movie cast model.
        [BindProperty]
        public MovieCastAssignment MovieCastAssignment { get; set; }


        //Gets the movie cast for update using a lamda query.
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
           ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name");
           ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Update the movie cast 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieCastAssignment).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCastAssignmentExists(MovieCastAssignment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the movie cast using a lamda query.
        private bool MovieCastAssignmentExists(int id)
        {
            return _context.MovieCastAssignment.Any(e => e.Id == id);
        }
    }
}
