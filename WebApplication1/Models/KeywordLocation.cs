using System;

namespace DataToAdvertisementTransformer.Models
{
    public class KeywordLocation
    {
        public int Id { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
    }
}