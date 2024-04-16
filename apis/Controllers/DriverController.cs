using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apis.Controllers
{
    [Route("api/v1/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepo _dirRepo;
        private readonly ResultError _resultError;

        public DriverController(IDriverRepo dirRepo, ResultError resultError)
        {
            _dirRepo = dirRepo;
            _resultError = resultError;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = new ResponseData<IEnumerable<Driver>>(StatusCodes.Status200OK, "Get All Driver Successful!!", await _dirRepo.Get());
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, "Get One Driver Successful!!", await _dirRepo.Get(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Driver dispatcher)
        {
            try
            {
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, "Create New Driver Successful!!", await _dirRepo.Create(dispatcher));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] Driver driver)
        {
            try
            {
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, "Update Driver Successful!!", await _dirRepo.Put(id, driver));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, "Delete Driver Successful!!", await _dirRepo.Delete(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
