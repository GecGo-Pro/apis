using apis.Models;
using System.Drawing;

namespace apis.SeedData
{
    public class DriverSeedData
    {
        public static Driver[] DriverData()
        {
            return new Driver[]
            {
             new Driver{ id=1,phone_number="1234234523", name="Nguyen Van C", password="abcd", address="HCM",longitude="106.666357",latitude="10.800450",is_active=1,status=0}
            };
        }
    }
}
