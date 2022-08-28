namespace Lesson8
{
    public interface IDeliveryAddressBuilder
    {
        void BuildZipCode();

        void BuildCountry();

        void BuildRegion();

        void BuildCity();

        void BuildStreet();

        void BuildHouse();

        void BuildHouseLetter();

        void BuildApartNumber();

        Address GetAddress();
    }
}
