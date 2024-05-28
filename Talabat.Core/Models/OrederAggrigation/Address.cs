namespace Talabat.Core.Models.OrederAggrigation
{
    public class Address
    {
        public Address()
        {
            
        }
        public Address(string fname, string lname, string street, string city, string country)
        {
            Fname = fname;
            Lname = lname;
            Street = street;
            City = city;
            Country = country;
        }

        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}