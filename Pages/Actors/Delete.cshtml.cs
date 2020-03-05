using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie_Database_Core_Web_APP.BusinessLayer;
using Movie_Database_Core_Web_APP.Models;

namespace Movie_Database_Core_Web_APP.Pages.Actors
{
    //Removes the Actor from the database
    public class DeleteModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public DeleteModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //binds the actor model.
        [BindProperty]
        public Actor Actor { get; set; }

        //Gets the actor for delete uses a lamda query to get the actor
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor =_context.Actor.FirstOrDefault(m => m.Id == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the Actor uses  a linq query to get the Actor.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = (from actors in _context.Actor
                     where actors.Id == id
                     select actors).FirstOrDefault();

            if (Actor != null)
            {
                _context.Actor.Remove(Actor);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
