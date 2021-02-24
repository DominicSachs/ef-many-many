using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MigrationTableNames
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<TestDbContext>(
                        options =>
                            options.UseSqlServer("Data Source=.;Initial Catalog=test;Integrated Security=True",
                                                 x => x.MigrationsAssembly(typeof(Program).Assembly.FullName)));
                });
    }
}