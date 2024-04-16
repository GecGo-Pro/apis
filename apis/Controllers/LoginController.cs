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
        private readonly ICustomerRepo _cusRepo;
        private readonly ResultError _resultError;

        public loginController(ICustomerRepo cusRepo, ResultError resultError)
        {
            _cusRepo = cusRepo;
            _resultError = resultError;
        }

        [HttpPost("/dispatcher/send_otp")]
        public async Task<ActionResult> SendOTP([FromForm] string phone)
        {
            try
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successful!!",  await _cusRepo.CreateOTP(phone) );
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("dispatcher/verify_otp")]
        public async Task<ActionResult> VeryfyOTP([FromForm] string phone, [FromForm] string otp)
        {
            try
            {
                string token = await _cusRepo.VeryfyOTP(phone, otp);
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Login successful!!",token);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
