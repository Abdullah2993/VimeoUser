using System.Collections.Generic;

namespace VimeoUser.Package
{
    public class Datum
    {
        public string uri { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string link { get; set; }

        public int duration { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public string created_time { get; set; }

        public string modified_time { get; set; }

        public List<string> content_rating { get; set; }

        public string license { get; set; }

        public Privacy privacy { get; set; }

        public Pictures pictures { get; set; }

        public List<object> tags { get; set; }

        public Stats stats { get; set; }

        public Metadata metadata { get; set; }

        public object embed_presets { get; set; }

        public User user { get; set; }

        public object app { get; set; }

        public string status { get; set; }
    }
}