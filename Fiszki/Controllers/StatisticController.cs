using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiszki.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Fiszki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        // GET: api/Statistic
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;  
            var id = identity.FindFirst(ClaimTypes.Name).Value;

            if (identity == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int ID = Int32.Parse(id);
            var statistics = StatisticRepository.GetStatistic(ID);
            return Ok(statistics);
        }
    }
}
