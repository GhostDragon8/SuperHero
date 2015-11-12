using System.Collections.Generic;

namespace SuperHero.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string Bio { get; set; }

        public virtual Demographics Demographics { get; set; }
        public virtual List<Interests> Interests { get; set; }
        public virtual Photots Photos { get; set; }
    }
}