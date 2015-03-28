using System.Collections.Generic;

namespace VimeoUser.Package
{
    public class User
    {
        public string uri { get; set; }

        public string name { get; set; }

        public string link { get; set; }

        public string location { get; set; }

        public string bio { get; set; }

        public string created_time { get; set; }

        public string account { get; set; }

        public Pictures3 pictures { get; set; }

        public List<Website> websites { get; set; }

        public Metadata2 metadata { get; set; }
    }
}