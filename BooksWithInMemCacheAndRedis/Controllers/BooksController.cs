using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.DataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    /// <summary>
    /// Books Controller
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksRepository _repo;
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository">Repo</param>
        public BooksController(IBooksRepository repository)
        {
            _repo = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Book</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Book>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repo.GetBooksAsync();
            
            return Ok(books);
        }
    }
}