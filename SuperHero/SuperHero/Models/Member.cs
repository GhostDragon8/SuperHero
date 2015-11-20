using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        //Hero name to login
        [Display(Name = "Hero Name")]
        public string HeroName { get; set; }

        //name displayed on site
        [Display(Name ="Username")]
        public string UserName { get; set; }

        [Display(Name="Date Joined")]
        public DateTime DateJoined { get; set; }

        [Display(Name = "Last Login")]
        public DateTime LastLogin { get; set; }

        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }
    }

    public class MemberDbContext: DbContext
    {
        public DbSet<Member> Member { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>()
                .HasOptional<Profile>(m => m.Profile)
                .WithRequired(m => m.Member)
                .Map(p => p.MapKey("MemberID"));
        }

        public System.Data.Entity.DbSet<SuperHero.Models.Profile> Profiles { get; set; }
    }

    

}