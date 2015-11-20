using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SuperHero.Models
{
    public class Photos
    {
        [Key]
        public int PhotoID { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        public bool ProfilePic { get; set; }

   
    }

    public class PhotosDbContext : DbContext
    {
        public DbSet<Photos> Photos { get; set; }
    }
}