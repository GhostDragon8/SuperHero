using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string Recipient { get; set; }

        [Display(Name="Message")]
        public string MessageText { get; set; }
        public DateTime DateSent { get; set; }
        public bool Read { get; set; }
        public int ThreadID { get; set; }
    }

    public class MessageDbContext : DbContext
    {
        public DbSet<Message> Message { get; set; }
    }
}