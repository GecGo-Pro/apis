using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Mvc;
namespace apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICustomerRepo _cusRepo;

        public LoginController(ICustomerRepo cusRepo)
        {
            _cusRepo = cusRepo;;
        }

        [HttpPost]
        public  async Task<ActionResult> SendOTP(string phone)
        {
            try
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Send OTP successfully",  await _cusRepo.CreateOTP(phone) );
                return Ok(response);
            }
            catch (MyException ex)
            {
                var response = new ResponseData<string>(ex.StatusCode, ex.Message, null);
                return BadRequest(response);
            }
            catch (Exception)
            {
                var response = new ResponseData<string>(500, "Fail", null);
                return BadRequest(response);
            }
        }
        [HttpPost("/verify_otp")]
        public async Task<ActionResult> VeryfyOTP(string phone, string otp)
        {
            try
            {
                string token = await _cusRepo.VeryfyOTP(phone, otp);
                var response = new ResponseData<string>(StatusCodes.Status200OK, "Login Successfull", token);
                return Ok(response);
            }
            catch (MyException ex)
            {
                var response = new ResponseData<string>(ex.StatusCode, ex.Message, null);
                return BadRequest(response);
            }
            catch (Exception)
            {
                var response = new ResponseData<string>(500, "Fail", null);
                return BadRequest(response);
            }
        }
    }
}
