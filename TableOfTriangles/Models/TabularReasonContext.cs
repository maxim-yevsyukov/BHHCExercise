using Microsoft.EntityFrameworkCore;

namespace BHHCExercise.Models
{
    public class TabularReasonContext : DbContext
    {
        public TabularReasonContext()
        {

        }

        public TabularReasonContext(DbContextOptions<TabularReasonContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<TabularReason>().HasKey(tt => new { tt.Row, tt.Column });
        }

        public DbSet<TabularReason> TabularReasons { get; set; }
    }
}
