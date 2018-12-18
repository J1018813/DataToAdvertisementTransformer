using System.Collections.Generic;

namespace DataToAdvertisementTransformer.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<KeywordLocation> KeywordLocations { get; set; }
    }
}