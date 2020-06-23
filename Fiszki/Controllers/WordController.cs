using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fiszki.Models;
using Fiszki.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiszki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        // GET: api/Word
        [Authorize]
        [HttpGet]
        public List<WordDTO> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.Name).Value;
            if (identity == null)
            {
                Response.StatusCode = 404;
            }
            int ID = Int32.Parse(userId);

            return WordsRepository.GetWordsList(ID);
        }

        // GET: api/Word/5
        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public WordDTO Get(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var UserId = identity.FindFirst(ClaimTypes.Name).Value;
            if (identity == null)
            {
                Response.StatusCode = 404;
            }
            int userId = Int32.Parse(UserId);

            return WordsRepository.GetWordId(userId, id);
        }

    }
}
