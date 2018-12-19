using System;

namespace DataToAdvertisementTransformer.DataTransferObjects
{
    public class KeywordLocationDto : KeywordDto
    {
        public string Location { get; set; }
        public DateTime DateTime { get; set; }

        public KeywordLocationDto(string name, int size) : base(name, size)
        {
        }
    }
}