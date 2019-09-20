using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Test
{
    public abstract class TestBase
    {
        protected readonly IServiceCollection services;
        protected static string MEMORY_DB_NAME = "";
        public TestBase()
        {
            services = new ServiceCollection();
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(MEMORY_DB_NAME);
            });
        }
    }
}
