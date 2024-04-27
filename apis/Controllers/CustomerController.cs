using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML.Voice;

namespace apis.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _cusRepo;
        private readonly ExceptionError _resultError;

        public CustomerController(ICustomerRepo cusRepo, ExceptionError resultError)
        {
            _cusRepo = cusRepo;
            _resultError = resultError;    
        }

        [AllowAnonymous]
        [HttpGet("/customer")]
        public async Task<ActionResult> OptionsAsDesiredByPhone(
                        [FromQuery] int page = 0,
                        [FromQuery] string phone_number = null,
                        [FromQuery] int limit =0,
                        [FromQuery] string sort ="")
        {
            try
            {
                OptionsAsDesiredByPhone optionsAsDesiredByPhone = new OptionsAsDesiredByPhone() { page =page,limit=limit,sort_by =sort};
                var response = new ResponseData<CustomerDTO>(StatusCodes.Status200OK, "Successfull", await _cusRepo.OptionsAsDesired(phone_number, optionsAsDesiredByPhone));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
