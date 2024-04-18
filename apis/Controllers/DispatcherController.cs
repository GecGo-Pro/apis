using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Mvc;


namespace apis.Controllers
{
    [Route("api/v1/dispatchers")]
    [ApiController]
    public class DispatcherController : ControllerBase
    {
        private readonly IDispatcherRepo _disRepo;
        private readonly ExceptionError _resultError;

        public DispatcherController(IDispatcherRepo disRepo, ExceptionError resultError)
        {
            _disRepo = disRepo;
            _resultError = resultError;
        }

        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            try
            {
                var response = new ResponseData<IEnumerable<Dispatcher>>(StatusCodes.Status200OK, "Get All Dispatcher Successful!!", await _disRepo.Get());
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
                var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Get One Dispatcher Successful!!", await _disRepo.Get(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Dispatcher dispatcher)
        {
            try
            {
                var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Create New  Dispatcher Successful!!", await _disRepo.Create(dispatcher));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] Dispatcher dispatcher)
        {
            try
            {
                var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Update Dispatcher Successful!!", await _disRepo.Put(id, dispatcher));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {
            try
            {
                var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Delete Dispatcher Successful!!", await _disRepo.Delete(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }
    }
}
