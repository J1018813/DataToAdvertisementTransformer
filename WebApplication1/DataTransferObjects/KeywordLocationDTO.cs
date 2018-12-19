using System;

namespace DataToAdvertisementTransformer.DataTransferObjects
{
    public class KeywordLocationDto : KeywordDto
    {
        public string Location { get; set; }
        public DateTime DateTime { get; set; }

        public KeywordLocationDto(string keyword, int amount) : base(keyword, amount)
        {
        }
    }
}