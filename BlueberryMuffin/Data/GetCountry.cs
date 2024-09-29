namespace BlueberryMuffin.Data
{
    public class GetCountry : BaseCountry
    {
        public int Id { get; set; }
    }

    public class CreateCountry : BaseCountry
    {
    }

    public class CountryDetails : GetCountry
    {
        public IList<GetHotel> Hotels { get; set; }
    }
}
