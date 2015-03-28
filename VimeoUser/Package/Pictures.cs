using System.Collections.Generic;

namespace VimeoUser.Package
{
    public class Pictures
    {
        public string uri { get; set; }

        public bool active { get; set; }

        public List<Size> sizes { get; set; }
    }
}