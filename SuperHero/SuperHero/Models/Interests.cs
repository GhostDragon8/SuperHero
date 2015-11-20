using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SuperHero.Models
{
    public class Interests
    {
        [Key]
        public int InterestID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

      
    }

    public class InterestDbContext : DbContext
    {
        public DbSet<Interests> Interests { get; set; }
    }
}