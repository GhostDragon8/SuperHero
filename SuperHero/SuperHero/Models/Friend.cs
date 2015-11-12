using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Friend
    {
        public int FriendID { get; set; }

        public int MemberID { get; set; }
        public virtual Member Member { get; set; }

        public DateTime DateFriended { get; set; }
    }
}