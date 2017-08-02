using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    public class Artist

    {

        public int ArtistId { get; set; }

        public string Name { get; set; }

    }
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
   
    public class Album
    {
        
        public int AlbumId { get; set; }
        
        public int GenreId { get; set; }
       
        public int ArtistId { get; set; }
        
        
        public string Title { get; set; }
      
        public decimal Price { get; set; }
       
        public string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}