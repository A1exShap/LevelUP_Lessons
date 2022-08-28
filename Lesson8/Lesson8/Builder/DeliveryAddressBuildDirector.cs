namespace Lesson8
{
    public class DeliveryAddressBuildDirector
    {
        private IDeliveryAddressBuilder _deliveryAddressBuilder;

        public DeliveryAddressBuildDirector(IDeliveryAddressBuilder deliveryAddressBuilder)
        {
            _deliveryAddressBuilder = deliveryAddressBuilder;
        }

        public void CreateAddress()
        {
            _deliveryAddressBuilder.BuildZipCode();

            _deliveryAddressBuilder.BuildCountry();

            _deliveryAddressBuilder.BuildRegion();

            _deliveryAddressBuilder.BuildCity();

            _deliveryAddressBuilder.BuildStreet();

            _deliveryAddressBuilder.BuildHouse();

            _deliveryAddressBuilder.BuildHouseLetter();

            _deliveryAddressBuilder.BuildApartNumber();
        }

        public Address GetAddress()
            => _deliveryAddressBuilder.GetAddress();
    }
}
