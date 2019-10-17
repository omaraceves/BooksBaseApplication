using Books.API.Context;
using Books.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.DataServices
{
    /// <summary>
    /// Books repo
    /// </summary>
    public class BooksRepository : IBooksRepository
    {
        private BooksContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Context</param>
        public BooksRepository(BooksContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds book
        /// </summary>
        /// <param name="b">Book</param>
        public void AddBook(Book b)
        {
            _context.Books.Add(b);
        }

        /// <summary>
        /// Saves Changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <returns>Collection of books</returns>
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync() ?? null;
        }
    }
}
