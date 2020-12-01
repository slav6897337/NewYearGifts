namespace NewYearGifts
{
    public class Price
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }

        public ConvertPrice converted { get; set; }
    }
}