using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueberryMuffin.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Autor { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
