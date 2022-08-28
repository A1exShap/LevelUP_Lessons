using Lesson1.DataValidator;

namespace Lesson8
{
    public class DeliveryAddressBuilder : IDeliveryAddressBuilder
    {
        private Address _address;

        public DeliveryAddressBuilder()
        {
            _address = new Address();
        }

        public void BuildApartNumber()
        {
            var apartNum = 0;

            GetInt(AddressElement.ApartspNumber, ref apartNum);

            _address.ApartNumber = apartNum;
        }

        public void BuildCity()
        {
            var city = string.Empty;

            GetString(AddressElement.City, ref city);

            _address.City = city;
        }

        public void BuildCountry()
        {
            var country = string.Empty;

            GetString(AddressElement.Country, ref country);

            _address.Country = country;
        }

        public void BuildHouse()
        {
            var houseNum = 0;

            GetInt(AddressElement.House, ref houseNum);

            _address.House = houseNum;
        }

        public void BuildHouseLetter()
        {
            var houseLetter = string.Empty;

            GetString(AddressElement.HousespLeter, ref houseLetter);

            _address.HouseLetter = houseLetter;
        }

        public void BuildZipCode()
        {
            var zipCode = 0;

            GetInt(AddressElement.ZipspCode, ref zipCode);

            _address.ZipCode = zipCode;
        }

        public void BuildRegion()
        {
            var region = string.Empty;

            GetString(AddressElement.Region, ref region);

            _address.Region = region;
        }

        public void BuildStreet()
        {
            Console.WriteLine("\nPlease enter the street");
            _address.Street = Console.ReadLine();
        }

        public Address GetAddress()
            => _address;

        private void GetString(AddressElement addressElement, ref string str)
        {
            var element = addressElement.ToString().Replace("sp", " ").ToLower();

            while(true)
            {
                Console.WriteLine($"\nPlease enter the {element}");

                str = Console.ReadLine();

                if (DataValidator.Validate(str, ValidateMethod.Name, out _) || (str.Length == 0 && addressElement == AddressElement.HousespLeter)) return;
                else Console.WriteLine($"An invalid {element} was entered");
            }
        }

        private void GetInt(AddressElement addressElement, ref int num)
        {
            var element = addressElement.ToString().Replace("sp", " ").ToLower();

            while (true)
            {
                Console.WriteLine($"\nPlease enter the {element}");

                var input = Console.ReadLine();

                if (int.TryParse(input, out int nm) || (input.Length == 0 && addressElement == AddressElement.ApartspNumber))
                {
                    num = nm;
                    return;
                }
                else Console.WriteLine($"An invalid {element} was entered");
            }
        }
    }
}
