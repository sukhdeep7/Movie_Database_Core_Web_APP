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

namespace Movie_Database_Core_Web_APP.Pages.Actors
{
    //Updates the actor.
    public class EditModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public EditModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Binds the actor model.
        [BindProperty]
        public Actor Actor { get; set; }

        //Gets the Actor for update using a lamda  query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor =  _context.Actor.FirstOrDefault(m => m.Id == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Update the actor.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Actor).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(Actor.Id))
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

        //Checks the actor using a lamda query.
        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.Id == id);
        }
    }
}
