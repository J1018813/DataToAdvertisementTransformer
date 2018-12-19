using Newtonsoft.Json;

namespace DataToAdvertisementTransformer.DataTransferObjects
{
    public class KeywordDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
        
        public KeywordDto(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}