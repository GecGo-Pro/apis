
using apis.Models;
using System.Drawing;

namespace apis.SeedData
{
    public class DispatcherSeedData
    {
        public static Dispatcher[] DispatcherData()
        {
            return new Dispatcher[]
            {
             new Dispatcher{id=1, phone_number="01212345678",email="", name="Nguyen Van B", otp=654321, avatar="" }
            };
        }
    }
}
