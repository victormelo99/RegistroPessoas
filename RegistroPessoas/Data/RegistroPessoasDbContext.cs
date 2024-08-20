using Microsoft.EntityFrameworkCore;
using RegistroPessoas.Models;

namespace RegistroPessoas.Data
{
    public class RegistroPessoasDbContext : DbContext
    {
        public RegistroPessoasDbContext(DbContextOptions<RegistroPessoasDbContext> options) : base(options) 
        {
        }
        public DbSet<Person> Person { get; set; }

    }
}
