using WAD_BookLibrary_8574.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_BookLibrary_8574.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();


                // Add Customers
                var austin = new Customer { Name = "Austin Nelson" };

                var julian = new Customer { Name = "Julian Long" };

                var isabel = new Customer { Name = "Isabel  Miller" };

                context.Customers.Add(austin);
                context.Customers.Add(julian);
                context.Customers.Add(isabel);

                // Add Author
                var authorElena = new Author
                {
                    Name = "Elena Ferrante",
                    Books = new List<Book>()
                {
                    new Book { Title = "My Brilliant Friend" },
                    new Book { Title = "The Story of a New Name" }
                }
                };

                var authorGillian = new Author
                {
                    Name = "Gillian Flynn",
                    Books = new List<Book>()
                {
                    new Book { Title = "Gone Girl"},
                    new Book { Title = "Dark Places"},
                    new Book { Title = "The Grownup"}
                }
                };

                context.Authors.Add(authorElena);
                context.Authors.Add(authorGillian);

                context.SaveChanges();
            }
        }
    }
}
