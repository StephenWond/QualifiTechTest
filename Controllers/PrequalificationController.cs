using Microsoft.AspNetCore.Mvc;
using QualifiTest.BusinessLogic;
using QualifiTest.Models;

namespace QualifiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrequalificationController : ControllerBase
    {
        private readonly IPrequalificationServiceManager _prequalificationServiceManager;
        private readonly ILogger<PrequalificationController> _logger;

        public PrequalificationController(IPrequalificationServiceManager prequalificationServiceManager,
            ILogger<PrequalificationController> logger)
        {
            _prequalificationServiceManager = prequalificationServiceManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPrequalificationApplication(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Prequalification application request received");

                var loanProducts = await _prequalificationServiceManager.SubmitPrequalificationApplication(customer);

                _logger.LogInformation("Prequalification application processed");
                return Ok(loanProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }
    }
}