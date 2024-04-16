using System.Text.RegularExpressions;

namespace apis.Utils
{
    public partial class MyRegex
    {
        [GeneratedRegex("^0\\d{8,10}$")]
        public static partial Regex RegexPhone();

        [GeneratedRegex("^\\d{6}$")]
        public static partial Regex RegexOTP();

        [GeneratedRegex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")]
        public static partial Regex RegexEmail();



    }
}
