using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TDDAPiQuiz.Data;
namespace TDDAPiQuiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TDDController : ControllerBase
    {
        private readonly TDDContext _context;

        public TDDController(TDDContext context)
        {
            _context = context;
        }

        [HttpGet("ContextTest")]
        public IActionResult ContextTest()
        {
            if (_context != null)
            {
                return Ok("Context successful!");
            }
            else
            {
                return StatusCode(500, "Context not successful");
            }
        }

        [HttpGet("GetTDD")]
        public IActionResult GetTDD()
        {
            return Ok(_context.TDDTable.ToList());
        }
    }
}