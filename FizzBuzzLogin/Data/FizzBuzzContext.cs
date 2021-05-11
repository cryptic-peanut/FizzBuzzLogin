using FizzBuzzLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzLogin.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext(DbContextOptions<FizzBuzzContext> options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}
