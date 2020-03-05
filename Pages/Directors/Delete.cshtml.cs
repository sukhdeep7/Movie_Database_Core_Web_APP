using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie_Database_Core_Web_APP.BusinessLayer;
using Movie_Database_Core_Web_APP.Models;

namespace Movie_Database_Core_Web_APP.Pages.Directors
{

    //Delete the Director .
    public class DeleteModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public DeleteModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Binds the director model
        [BindProperty]
        public Director Director { get; set; }

        //Get the Director for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Director =  _context.Director.FirstOrDefault(m => m.Id == id);

            if (Director == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the Director uses a lamda query to select the director
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Director = (from director in _context.Director
                        where director.Id == id
                        select director).FirstOrDefault();

            if (Director != null)
            {
                _context.Director.Remove(Director);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
