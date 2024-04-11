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
        private readonly ResultResponse _resultResponse;

        public DispatcherController(IDispatcherRepo disRepo, ResultResponse resultResponse)
        {
            _disRepo = disRepo;
            _resultResponse = resultResponse;
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
                return _resultResponse.GetActionResult(ex);
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
                return _resultResponse.GetActionResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Dispatcher dispatcher)
        {
            try
            {
                var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Create New  Dispatcher Successful!!", await _disRepo.Create(dispatcher));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultResponse.GetActionResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Dispatcher dispatcher)
        {
            try
            {
                var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Update Dispatcher Successful!!", await _disRepo.Put(id, dispatcher));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultResponse.GetActionResult(ex);
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
                return _resultResponse.GetActionResult(ex);
            }
        }
    }
}
