using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/Authors")]
    public class AuthorsController : Controller
    {
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            return Ok(AuthorsDatastore.Current.Authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            // find city
            var authorToReturn = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == id);
            if (authorToReturn == null)
            {
                return NotFound();
            }
            return Ok(authorToReturn);
        }
    }
}