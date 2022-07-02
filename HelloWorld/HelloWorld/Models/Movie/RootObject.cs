using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models.Movie
{
    public class Rootobject
    {
        public int page { get; set; }
        public Movie[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
