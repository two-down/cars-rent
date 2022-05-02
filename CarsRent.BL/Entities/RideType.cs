namespace CarsRent.BL.Entities
{
    public static class RideTypeClass
    {
        public static string RideTypeToString(RideType rideType)
        {
            switch (rideType)
            {
                case RideType.InTheCity:
                    return "по городу";

                case RideType.OutsideTheCity:
                    return "за городом";

                default:
                    return string.Empty;
            }
        }
    }

    public enum RideType
    {
        InTheCity,
        OutsideTheCity
    }
}