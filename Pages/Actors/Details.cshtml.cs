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
    //Details of the actor.
    public class DetailsModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public DetailsModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Holds the actor model.
        public Actor Actor { get; set; }

        //Gets the actor using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = _context.Actor.FirstOrDefault(m => m.Id == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
