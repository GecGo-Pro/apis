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

        private string name = "Driver";

        public DriverController(IDriverRepo dirRepo, ExceptionError resultError)
        {
            _dirRepo = dirRepo;
            _resultError = resultError;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = new ResponseData<IEnumerable<Driver>>(StatusCodes.Status200OK, Variable.GetAll(name), await _dirRepo.Get());
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
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, Variable.GetOne(name), await _dirRepo.Get(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DriverDTO driverDTO)
        {
            try
            {
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, Variable.Post(name), await _dirRepo.Create(driverDTO));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DriverDTO driverDTO)
        {
            try
            {
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, Variable.Put(name), await _dirRepo.Put(id, driverDTO));
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
                var response = new ResponseData<Driver>(StatusCodes.Status200OK, Variable.Delete(name), await _dirRepo.Delete(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
