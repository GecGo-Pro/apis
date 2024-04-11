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
        private readonly ResultResponse _resultResponse;

        public loginController(ICustomerRepo cusRepo, ResultResponse resultResponse)
        {
            _cusRepo = cusRepo;
            _resultResponse = resultResponse;
        }

        [HttpPost]
        public  async Task<ActionResult> SendOTP(string phone)
        {
            try
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successful!!",  await _cusRepo.CreateOTP(phone) );
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultResponse.GetActionResult(ex);
            }
        }
        [HttpPost("/verify_otp")]
        public async Task<ActionResult> VeryfyOTP(string phone, string otp)
        {
            try
            {
                string token = await _cusRepo.VeryfyOTP(phone, otp);
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Login successful!!",token);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultResponse.GetActionResult(ex);
            }
        }
    }
}
