using apis.IRepository;
using apis.Models;
using backend.ResponseData;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
namespace apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendSmsController : ControllerBase
    {
        private readonly ITwilioRestClient client;
        private readonly ICustomerRepo cusRepo;
        private readonly IConfiguration _configuration;

        public SendSmsController(ITwilioRestClient client, ICustomerRepo cusRepo, IConfiguration configuration)
        {
            this.client = client;
            this.cusRepo = cusRepo;
            _configuration = configuration;
        }

        [HttpPost]
        public  async Task<ActionResult> SendOTP(string phone)
        {
            try
            {
                if (Regex.IsMatch(phone, @"^0\d{8,10}$"))
                {
                    bool check_existed = await cusRepo.CheckExist(phone);
                    if (check_existed)
                    {
                        string set_otp = await cusRepo.CreateOTP(phone);
                        if (set_otp != null)
                        {
                            if (_configuration["ENABLE_OTP_SENDING"]?.ToLower() == "true")
                            {
                                var send_otp = MessageResource.Create(to:"+84"+ phone, from: "+12058582939", body: "OTP: ", client: client);
                                if (send_otp != null)
                                {
                                    var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successfully", "OTP:" + set_otp + " time :" + DateTime.UtcNow, null);
                                    return Ok(response);
                                }
                                else
                                {
                                    var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Send OTP Fail", "OTP:" + set_otp, null);
                                    return BadRequest(response);
                                }
                            }
                            else
                            {
                                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successfully", "OTP:" + set_otp + " time :" + DateTime.UtcNow, null);
                                return Ok(response);
                            }
                        }
                        else
                        {
                            var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Create OTP Fail", "OTP: ", null);
                            return BadRequest(response);
                        }
                    }
                    else
                    {
                        var response = new ResponseData<string>(StatusCodes.Status404NotFound, "Phone not existing", phone, null);
                        return BadRequest(response);
                    }
                }
                else
                {
                    var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Phone invalid ", phone, null);
                    return BadRequest(response);
                }


            }
            catch (Exception e)
            {
                var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Fail", "OTP", null);
                return BadRequest(response);
            }
        }
        [HttpPost("/login")]
        public async Task<ActionResult> CheckOTP(string phone, string otp)
        {
            try
            {
                if (Regex.IsMatch(phone, @"^\d+$") && Regex.IsMatch(otp, @"^\d+$"))
                {
                    bool check_existed = await cusRepo.CheckExist(phone);
                    if (check_existed)
                    {
                        Customer result_otp = await cusRepo.CheckOTP(phone, otp);
                        if (result_otp != null)
                        {
                            if (DateTime.Compare(result_otp.otp_life, DateTime.UtcNow) > 0)
                            {
                                string token = cusRepo.TokenCustomer(result_otp);
                                var response = new ResponseData<string>(StatusCodes.Status200OK, "Login Successfull", token, null);
                                return Ok(response);
                            }
                            else
                            {
                                var response = new ResponseData<Customer>(StatusCodes.Status400BadRequest, "OTP Expired", null, null);
                                return BadRequest(response);
                            }
                        }
                        else
                        {
                            var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "OTP error", null, null);
                            return BadRequest(response);
                        }
                    }
                    else
                    {
                        var response = new ResponseData<string>(StatusCodes.Status404NotFound, "Phone not existing", phone, null);
                        return BadRequest(response);
                    }
                }
                else
                {
                    var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Phone invalid or OTP invalid", phone, null);
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                var response = new ResponseData<string>(StatusCodes.Status400BadRequest, "Fail", null, "Check OTP Fail");
                return BadRequest(response);
            }
        }
    }
}
