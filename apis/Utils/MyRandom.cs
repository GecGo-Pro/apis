using System.Runtime.CompilerServices;

namespace apis.Utils
{
    public class MyRandom
    {
        private static Random random = new Random();

        public static string OTP()
        {
           return new(Enumerable.Repeat("0123456789", 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
