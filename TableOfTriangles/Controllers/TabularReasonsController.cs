using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BHHCExercise.Models;

namespace BHHCExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabularReasonsController : ControllerBase
    {
        private readonly TabularReasonContext _context;

        public TabularReasonsController(TabularReasonContext context)
        {
            _context = context;
        }

        // GET: api/TabularReasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabularReason>>> GetTabularReasons()
        {
            return await _context.TabularReasons.ToListAsync();
        }
    }
}
