using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SuperHero.Models
{
    public class Profile
    {
        //Primary Key
        [Key]
        public int ProfID { get; set; }
        public string Bio { get; set; }

        public int MemID { get; set; }
        public virtual Member Member { get; set; }

        public virtual Demographics Demographics { get; set; }
        public virtual Interests Interests { get; set; }
        public virtual Photos Photos { get; set; }
    }

    public class ProfileDbContext : DbContext
    {
        public DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Profile>()
                .HasOptional<Member>(m => m.Member)
                .WithRequired(m => m.Profile)
                .Map(p => p.MapKey("ProfID"));
        }

        public System.Data.Entity.DbSet<SuperHero.Models.Member> Members { get; set; }
    }
}