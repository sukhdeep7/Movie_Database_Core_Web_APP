using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie_Database_Core_Web_APP.BusinessLayer;

namespace Movie_Database_Core_Web_APP.Models
{
    //Connects the business layer to the database.
    public class Movie_Database_Core_Web_APPContext : DbContext
    {
        public Movie_Database_Core_Web_APPContext (DbContextOptions<Movie_Database_Core_Web_APPContext> options)
            : base(options)
        {
        }

        public DbSet<Movie_Database_Core_Web_APP.BusinessLayer.Actor> Actor { get; set; }

        public DbSet<Movie_Database_Core_Web_APP.BusinessLayer.Director> Director { get; set; }

        public DbSet<Movie_Database_Core_Web_APP.BusinessLayer.MovieCastAssignment> MovieCastAssignment { get; set; }

        public DbSet<Movie_Database_Core_Web_APP.BusinessLayer.Movie> Movie { get; set; }
    }
}
