namespace DataToAdvertisementTransformer.DataTransferObjects
{
    public class KeywordDto
    {
        public string Keyword { get; set; }
        public int Amount { get; set; }
        
        public KeywordDto(string keyword, int amount)
        {
            Keyword = keyword;
            Amount = amount;
        }
    }
}