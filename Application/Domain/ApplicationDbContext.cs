using Application.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Domain
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Goods> Goods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
    }
}
