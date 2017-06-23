using System.Data.Entity;
using WebApplication.Models;

namespace WebApplication.Context
{
    public class WebApplicationContext : DbContext
    {
        public WebApplicationContext()
            :base("WebApplicationContext")
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}