using System.Collections.Generic;
using System.Linq;

namespace DataToAdvertisementTransformer.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<KeywordLocation> KeywordLocations { get; set; }
        public int Amount => KeywordLocations != null ? KeywordLocations.Sum(kl => kl.Amount) : 0;
    }
}