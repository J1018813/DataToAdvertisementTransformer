using System;

namespace DataToAdvertisementTransformer.DataTransferObjects
{
    public class KeywordLocationDTO
    {
        public string Keyword { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
        
    }
}