using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Friend
    {
        [Key]
        public int MemberID { get; set; }
        
        public DateTime DateFriended { get; set; }
    }

    public class FriendDbContext : DbContext
    {
        public DbSet<Friend> Friend { get; set; }
    }
}