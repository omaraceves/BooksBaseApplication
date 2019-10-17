using Books.API.DataServices;
using Books.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Context
{
    /// <summary>
    /// Seed books into In Memory DB
    /// </summary>
    public class InMemoryDBInitializer
    {
        /// <summary>
        /// Initialize In memory DB
        /// </summary>
        /// <param name="context">Books Context</param>
        public static void Initialize(IBooksRepository repo)
        {
            var books = new Book[]
            {
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Little Prince",
                    NumberOfPages = 116
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Silmarillion",
                    NumberOfPages = 454
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "A Game Of Thrones",
                    NumberOfPages = 995
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Head First Design Patterns",
                    NumberOfPages = 679
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Old And New VR Stories",
                    NumberOfPages = 267
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "A World Of Chairs",
                    NumberOfPages = 324
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Why You Want To Become A Software Developer",
                    NumberOfPages = 1
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Jurassic Universe: A New Reality",
                    NumberOfPages = 855
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Blankets",
                    NumberOfPages = 122
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Funkos Or Nendoroids?",
                    NumberOfPages = 235
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The History Of Mouse Peripherals And Why It Matters",
                    NumberOfPages = 122
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "How To Be A Pro Genji: The Definitive Guide",
                    NumberOfPages = 50
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Car Hacks",
                    NumberOfPages = 775
                }
            };

            foreach (var b in books)
            {
                repo.AddBook(b);
            }
            repo.SaveChanges();
        }
    }
}
