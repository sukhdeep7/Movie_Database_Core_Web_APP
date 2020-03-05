using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Database_Core_Web_APP.BusinessLayer
{
    //A Movie 
    public class Movie
    {
        //Movie id 
        public int Id { get; set; }

        //Movie name 
        public string Name { get; set; }

        //Movie Genres
        public string Genres { get; set; }

        //Movie director id 
        public int DirectorId { get; set; }

        //Movie director link
        public Director Director { get; set; }

        //Release year of the movie
        public int ReleaseYear { get; set; }
    }


    
}
