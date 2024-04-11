using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;

namespace apis.Utils
{
    public class SendSms
    {
        public bool Send(string phone, string body, ITwilioRestClient client)
        {
            MessageResource.Create(to: "+84" + phone, from: "+12058582939", body: body, client: client);
            return true;
        }
    }
}
