using backend.ResponseData;
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
        public  ActionResult SendOTP(string phone)
        {
            var send_otp =  MessageResource.Create
                (
                    to: phone,
                    from: "+12058582939",
                    body: "OTP: ",
                    client: client
                );
            if (send_otp != null)
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successfully", "OTP", null);
                return Ok(response);
            }
            else
            {
                var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Send OTP Fail", "OTP", null);
                return Ok(response);
            }
        }
    }
}
