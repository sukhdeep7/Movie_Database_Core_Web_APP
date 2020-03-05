using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Database_Core_Web_APP.BusinessLayer;
using Movie_Database_Core_Web_APP.Models;

namespace Movie_Database_Core_Web_APP.Pages.MovieCastAssigments
{
    //Adds a Movie cast assigmentment 
    public class CreateModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public CreateModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }


        //Gets the move cast assignment for delete.
        public IActionResult OnGet()
        {
        ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name");
        ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Name");
            return Page();
        }

        //Binds the movie cast model.
        [BindProperty]
        public MovieCastAssignment MovieCastAssignment { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //adds the movie cast to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieCastAssignment.Add(MovieCastAssignment);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
