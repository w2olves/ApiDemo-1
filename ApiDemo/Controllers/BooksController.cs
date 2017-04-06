using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/Books")]
    public class BooksController : Controller
    {
        [HttpGet("{authorId}/books")]
        public IActionResult Getbooks(int authorId)
        {
            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author.Books);
        }

        [HttpGet("{authorId}/books/{id}", Name = "GetPointOfInterest")]
        public IActionResult Getbook(int authorId, int id)
        {
            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            var books = author.Books.FirstOrDefault(p => p.Id == id);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
    }
}