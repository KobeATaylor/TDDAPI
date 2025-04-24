using Microsoft.EntityFrameworkCore;

namespace TDDAPiQuiz.Data
{
    public class TDDContext : DbContext
    {
        public TDDContext(DbContextOptions<TDDContext> options) : base(options) { }
    }
}
