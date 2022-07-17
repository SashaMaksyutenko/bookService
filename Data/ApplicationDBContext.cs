using System;
using bookService.Models;
using Microsoft.EntityFrameworkCore;

namespace bookService.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {
        }
    public DbSet<Category> Categories { get; set; }

}
}

