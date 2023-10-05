using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebScraping.Entities;


namespace WebScraping
{
    public class Startup : DbContext
    {
        public DbSet<Passagens> VOOS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var stringConexao = configuration.GetConnectionString("DefaultConnetion");

                optionsBuilder.UseSqlServer(stringConexao); // Substitua pela sua string de conexão
            }

        }

    }

}



