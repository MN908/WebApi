using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Bussiness.Processor.Interface;
using webAPI.Entity.Request;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobProcessor _IJobProcessor;

        private readonly ILogger<JobsController> _logger;

        public JobsController(IJobProcessor IJobProcessor , ILogger<JobsController> logger)
        {
            _IJobProcessor = IJobProcessor;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] JobCreateRequest request)
        {
            return Ok( await _IJobProcessor.CreateAsync(request));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            return Ok( await _IJobProcessor.GetById(id));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _IJobProcessor.DeleteAsync(id);

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobModel>>> GetAllAsync()
        {
            return Ok(await _IJobProcessor.GetAllAsync());
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateAsync([FromBody] JobUpdateRequest request)
        {
            await _IJobProcessor.UpdateAsync(request);

            return Ok( );
        }
    }
}
