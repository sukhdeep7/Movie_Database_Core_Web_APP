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

namespace Movie_Database_Core_Web_APP.Pages.Directors
{
    //Updates the director
    public class EditModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public EditModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //Binds the director model
        [BindProperty]
        public Director Director { get; set; }

        //Gets the director for edit using a lamda query.
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the director. 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Director).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(Director.Id))
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

        //Checks the director using a lamda query.
        private bool DirectorExists(int id)
        {
            return _context.Director.Any(e => e.Id == id);
        }
    }
}
