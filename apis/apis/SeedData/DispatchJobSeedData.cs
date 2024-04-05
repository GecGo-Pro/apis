using apis.Models;
using System.Drawing;

namespace apis.SeedData
{
    public class DispatchJobSeedData
    {
        public static DispatchJob[] DispatcherData()
        {
            return new DispatchJob[]
            {
             new DispatchJob{id=1,start_longitude="106.665794", start_latitude="10.800102", end_latitude="10.801418", end_longitude="106.661530", start_address="", end_address="", status=1, customer_id=1, dispatcher_id=1,driver_id=1, car_id=1 }
            };
        }
    }
}
