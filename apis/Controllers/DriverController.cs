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
        private readonly ExceptionError _resultError;
        private readonly Variable _variable;

        private string name = "Driver";

        public DriverController(IDriverRepo dirRepo, ExceptionError resultError, Variable variable)
        {
            _dirRepo = dirRepo;
            _resultError = resultError;
            _variable = variable;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = new ResponseData<IEnumerable<Driver>>(StatusCodes.Status200OK, _variable.GetAll(name), await _dirRepo.Get());
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
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, _variable.GetOne(name), await _dirRepo.Get(id));
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
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, _variable.Post(name), await _dirRepo.Create(dispatcher));
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
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, _variable.Put(name), await _dirRepo.Put(id, driver));
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
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, _variable.Delete(name), await _dirRepo.Delete(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
