using System;

namespace SuperHero.Models
{
    public class Photots
    {
        public int PhotoID { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool ProfilePic { get; set; }
    }
}