using System.Collections.Generic;

namespace VimeoUser.Package
{
    public class Followers
    {
        public string uri { get; set; }

        public List<string> options { get; set; }

        public int total { get; set; }
    }
}