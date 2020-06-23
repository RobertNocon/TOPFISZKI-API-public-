using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiszki.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Fiszki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public List<Progress> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.Name).Value;
            if (identity == null)
            {
                Response.StatusCode = 404;
            }
            int ID = Int32.Parse(userId);
            return ProgressRepository.GetProgress(ID);
        }


        //GET: api/Progress/5
        [Authorize]
        [HttpGet("{id}")]
        public List<Progress> Get(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.Name).Value;
            if (identity == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int ID = Int32.Parse(userId);
            return ProgressRepository.GetProgressId(ID, id);

        }


        // POST: api/Progress
        [Authorize]
        [HttpPost]
        public void Post([FromBody] Progress progresUpdate)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.Name).Value;
            if (identity == null)
            {
                Response.StatusCode = 404;
            }
            int ID = Int32.Parse(userId);
            ProgressRepository.AddProgress(progresUpdate, ID);  
        }

    }
}
