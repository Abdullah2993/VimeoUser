using System.Collections.Generic;

namespace VimeoUser.Package
{
    public class Results
    {
        public int total { get; set; }

        public int page { get; set; }

        public int per_page { get; set; }

        public Paging paging { get; set; }

        public List<Datum> data { get; set; }
    }
}