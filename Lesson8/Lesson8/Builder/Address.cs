namespace Lesson8
{
    public class Address
    {
        public int ZipCode { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int House { get; set; }

        public string HouseLetter { get; set; }

        public int ApartNumber { get; set; }

        public override string ToString()
        {
            var address = $"{ZipCode}, {Country}, {Region}, {City}, {Street}, ";
            address += HouseLetter.Length == 0 ? House : $"{House} {HouseLetter}";
            address += ApartNumber == 0 ? "" : $", {ApartNumber}";

            return address;
        }
    }
}
