using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;

namespace apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendSmsController : ControllerBase
    {
        private readonly ITwilioRestClient client;
        public SendSmsController(ITwilioRestClient client)
        {
            this.client = client;
        }
        [HttpPost]
        public IActionResult SendOTP(string phone)
        {
            MessageResource.Create
                (
                    to: phone,
                    from: "+12058582939",
                    body: "hello",
                    client: client
                );
            return Ok();
        }
    }
}
