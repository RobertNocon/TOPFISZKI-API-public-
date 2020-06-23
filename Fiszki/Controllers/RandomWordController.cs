using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiszki.Repositories;
using Fiszki.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Fiszki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomWordController : ControllerBase
    {
        // GET: api/RandomWord
        [Authorize]
        [HttpGet]
        public WordDTO Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var id = identity.FindFirst(ClaimTypes.Name).Value; //dekoduje id usera z tokena
            if (identity == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int ID = int.Parse(id);
            var response = WordsRepository.GetRandomWord(ID); //id usera
            return response;
        }
    }
}
