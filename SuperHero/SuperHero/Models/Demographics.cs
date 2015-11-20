using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SuperHero.Models
{
    public class Demographics
    {
        [Key]
        public int DemID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Display(Name = "Birthday")]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

    }

    public class DemDbContext : DbContext
    {
        public DbSet<Demographics> Demographics { get; set; }
    }
}