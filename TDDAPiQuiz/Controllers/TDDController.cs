using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TDDAPiQuiz.Data;
using TDDAPiQuiz.Models;
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

        [HttpPost("PostTDD")]
        public void PostTDD(TDDModel tdd)
        {
            _context.TDDTable.Add(tdd);
            _context.SaveChanges();
        }

        [HttpDelete("DeleteTDD")]
        public void DeleteTDD(int id)
        {
            var tdd = _context.TDDTable.FirstOrDefault(x => x.id == id);
            if(tdd != null)
            {
                _context.TDDTable.Remove(tdd);
                _context.SaveChanges();
            }
        }
    }
}