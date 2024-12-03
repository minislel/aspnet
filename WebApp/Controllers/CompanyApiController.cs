using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyApiController : ControllerBase
    {
        private MoviesContext _context;

        public CompanyApiController(MoviesContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetFiltered(string fragment)
        {
            return Ok(
                                _context.ProductionCompanies
                    .Where(m => m.CompanyName != null && m.CompanyName.ToLower().Contains(fragment.ToLower())).
                    AsTracking().AsEnumerable()
                );
        }
    }
}
