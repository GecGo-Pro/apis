using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace apis.Controllers
{
    [Route("api/v1/dispatch_job")]
    [ApiController]
    public class DispatchJobController : ControllerBase
    {
        private readonly IDispatchJobRepo _disJobRepo;
        private readonly ExceptionError _resultError;

        public DispatchJobController(IDispatchJobRepo disJobRepo, ExceptionError resultError)
        {
            _disJobRepo = disJobRepo;
            _resultError = resultError;
        }

        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            try
            {
                var response = new ResponseData<IEnumerable<DispatchJob>>(StatusCodes.Status200OK, "Get All Dispatcher Successful!!", await _disJobRepo.Get());
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
                var response = new ResponseData<DispatchJob>(StatusCodes.Status200OK, "Get One Dispatcher Successful!!", await _disJobRepo.Get(id));
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return _resultError.GetActionResult(ex);
            }
        }

        // [HttpPost]
        // public async Task<ActionResult> Post([FromBody] DispatcherDTO dispatcherDTO)
        // {
        //     try
        //     {
        //         var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Create New  Dispatcher Successful!!", await _disRepo.Create(dispatcherDTO));
        //         return Ok(response);
        //     }
        //     catch (HttpException ex)
        //     {
        //         return _resultError.GetActionResult(ex);
        //     }
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult> Put(int id, [FromBody] DispatcherDTO dispatcherDTO)
        // {
        //     try
        //     {
        //         var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Update Dispatcher Successful!!", await _disRepo.Put(id, dispatcherDTO));
        //         return Ok(response);
        //     }
        //     catch (HttpException ex)
        //     {
        //         return _resultError.GetActionResult(ex);
        //     }
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult>  Delete(int id)
        // {
        //     try
        //     {
        //         var response = new ResponseData<Dispatcher>(StatusCodes.Status200OK, "Delete Dispatcher Successful!!", await _disRepo.Delete(id));
        //         return Ok(response);
        //     }
        //     catch (HttpException ex)
        //     {
        //         return _resultError.GetActionResult(ex);
        //     }
        // }
    }
}
