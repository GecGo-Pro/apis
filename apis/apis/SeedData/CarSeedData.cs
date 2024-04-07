using apis.Models;
using System.Drawing;

namespace apis.SeedData
{
    public class CarSeedData
    {
       public static Car[] CarData()
        {
            return new Car[]
            {
                new Car{id=1, number_plate="49A 222222",type="6 cho",note="" , driver_id=1}
            };
        }

    }
}
