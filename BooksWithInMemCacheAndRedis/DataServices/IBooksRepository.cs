using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Entities;

namespace Books.API.DataServices
{
    /// <summary>
    /// Books Repo Interface
    /// </summary>
    public interface IBooksRepository
    {
        /// <summary>
        /// Adds a book
        /// </summary>
        /// <param name="b"></param>
        void AddBook(Book b);

        /// <summary>
        /// Saves Changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Gets Books
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
