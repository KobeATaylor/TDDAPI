using Microsoft.EntityFrameworkCore;
using TDDAPiQuiz.Models;

namespace TDDAPiQuiz.Data
{
    public class TDDContext : DbContext
    {
        public TDDContext(DbContextOptions<TDDContext> options) : base(options) { }

        public DbSet<TDDModel> TDDTable { get; set; }
    }
}
