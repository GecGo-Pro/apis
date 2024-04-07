using apis.Models;
using System.Drawing;

namespace apis.SeedData
{
    public class CustomerSeedData
    {
        public static Customer[] CustomerData()
        {
            return new Customer[]
            {
                new Customer{id=1, phone_number="0123456789", name="Nguyen Van A" , avatar= "", longitude="106.665794" ,latitude="10.800102" , otp=123456 }
            };
        }
    }
}
