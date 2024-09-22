namespace BlueberryMuffin.Data
{
    public class GetCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
    }

    public class CountryDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }

        public IList<GetHotel> Hotels { get; set; }
    }
}
