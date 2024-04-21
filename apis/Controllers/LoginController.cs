using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Mvc;

namespace apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly ICustomerOTPRepo _cusOTPRepo;
        private readonly IDispatcherOTPRepo _disOTPRepo;
        private readonly ExceptionError _resultError;

        public loginController(ICustomerOTPRepo cusOTPRepo, IDispatcherOTPRepo disOTPRepo, ExceptionError resultError)
        {
            _cusOTPRepo = cusOTPRepo;
            _disOTPRepo = disOTPRepo;
            _resultError = resultError;
        }

        [HttpPost("/customer/send_otp")]
        public async Task<ActionResult> CustomerSendOTP([FromForm] string phone)
        {
            try
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successful!!",  await _cusOTPRepo.CreateOTP(phone) );
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("/customer/verify_otp")]
        public async Task<ActionResult> CustomerVeryfyOTP([FromForm] string phone, [FromForm] string otp)
        {
            try
            {
                string token = await _cusOTPRepo.VeryfyOTP(phone, otp);
                var response = new ResponseData<Token>(StatusCodes.Status200OK, "Login successful!!", new Token(token));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("/dispatcher/send_otp")]
        public async Task<ActionResult> DispatcherSendOTP([FromForm] string phone)
        {
            try
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, Variable.SendOTP("dispatcher"), await _disOTPRepo.CreateOTP(phone));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("/dispatcher/verify_otp")]
        public async Task<ActionResult> DispatcherVeryfyOTP([FromForm] string phone, [FromForm] string otp)
        {
            try
            {
                string token = await _disOTPRepo.VeryfyOTP(phone, otp);
                var response = new ResponseData<Token>(StatusCodes.Status200OK, Variable.Login("dispatcher"), new Token(token));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
