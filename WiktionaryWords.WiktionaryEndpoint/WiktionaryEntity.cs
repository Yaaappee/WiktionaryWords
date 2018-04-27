using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WiktionaryWords.WiktionaryEndpoint
{
    public class WiktionaryEntity
    {
        public ParseEntity Parse { get; set; }
    }

    public class ParseEntity
    {
        public string Title { get; set; }

        public int PageId { get; set; }

        public int RevId { get; set; }

        public TextEntity Text { get; set; }
    }

    public class TextEntity
    {
        [JsonProperty(PropertyName = "*")]
        public string Html { get; set; }
    }
}
