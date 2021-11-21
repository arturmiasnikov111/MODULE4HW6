using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MODULE4HW6
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var root = @"/Users/arturmiasnykov/RiderProjects/MODULE4HW6/MODULE4HW6/Configuration/configuration.json";
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(root).Build();
            var dbOptionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbOptionBuilder.UseSqlServer(connectionString);

            return new ApplicationContext(dbOptionBuilder.Options);
        }
    }
}