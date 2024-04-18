using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Mvc;

namespace apis.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICustomerRepo _cusRepo;
        private readonly ResultError _resultError;

        public LoginController(ICustomerRepo cusRepo, ResultError resultError)
        {
            _cusRepo = cusRepo;
            _resultError = resultError;
        }

        [HttpPost("dispatcher/login")]
        public async Task<ActionResult> SendOTP([FromBody] DispatcherLoginDTO dispatcherLoginBody)
        {
            try
            {
                string phone = dispatcherLoginBody.Phone;
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successful!!", await _cusRepo.CreateOTP(phone));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPost("dispatcher/verify_otp")]
        public async Task<ActionResult> VeryfyOTP([FromBody] DispatcherVerifyOtpDTO dispatcherVerifyOtp)
        {
            try
            {
                string token = await _cusRepo.VeryfyOTP(dispatcherVerifyOtp.Phone, dispatcherVerifyOtp.Otp);
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Login successful!!", token);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
