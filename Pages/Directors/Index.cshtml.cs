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
    //Get all directors 
    public class IndexModel : PageModel
    {
        private readonly Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext _context;

        public IndexModel(Movie_Database_Core_Web_APP.Models.Movie_Database_Core_Web_APPContext context)
        {
            _context = context;
        }

        //List of directors 
        public IList<Director> Director { get;set; }

        //Gets all the directors using a linq query.
        public  void OnGet()
        {
            Director = (from director in _context.Director select director).ToList();
        }
    }
}
