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
        private readonly ICustomerOTPRepo _cusOTPRepo;
        private readonly IDispatcherOTPRepo _disOTPRepo;
        private readonly ExceptionError _resultError;

        public LoginController(ICustomerOTPRepo cusOTPRepo, IDispatcherOTPRepo disOTPRepo, ExceptionError resultError)
        {
            _cusOTPRepo = cusOTPRepo;
            _disOTPRepo = disOTPRepo;
            _resultError = resultError;
        }

        [HttpPost("/customer/login")]
        public async Task<ActionResult> CustomerSendOTP([FromBody] LoginDTO customerLogin)
        {
            try
            {
                string phone = customerLogin.Phone;
                var response = new ResponseData<string>(StatusCodes.Status200OK, Variable.SendOTP(Variable.Customer), await _cusOTPRepo.CreateOTP(phone));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("/customer/verify_otp")]
        public async Task<ActionResult> CustomerVeryfyOTP([FromBody] VerifyOtpDTO customerVerifyOtp)
        {
            try
            {
                string token = await _cusOTPRepo.VeryfyOTP(customerVerifyOtp.Phone, customerVerifyOtp.Otp);
                var response = new ResponseData<string>(StatusCodes.Status200OK, Variable.Login(Variable.Customer), token);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("/dispatcher/login")]
        public async Task<ActionResult> DispatcherSendOTP([FromBody] LoginDTO dispatcherLoginBody)
        {
            try
            {
                var response = new ResponseData<string>(StatusCodes.Status200OK, Variable.SendOTP(Variable.Dispatcher), await _disOTPRepo.CreateOTP(dispatcherLoginBody.Phone));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
        [HttpPost("/dispatcher/verify_otp")]
        public async Task<ActionResult> DispatcherVeryfyOTP([FromBody] VerifyOtpDTO dispatcherVerifyOtp)
        {
            try
            {
                string token = await _disOTPRepo.VeryfyOTP(dispatcherVerifyOtp.Phone, dispatcherVerifyOtp.Otp);
                var response = new ResponseData<Token>(StatusCodes.Status200OK, Variable.Login(Variable.Dispatcher), new Token(token));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
