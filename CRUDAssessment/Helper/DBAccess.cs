using CRUDAssessment.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDAssessment.Helper
{
    public class DBAccess : DbContext
    {
        public DBAccess(DbContextOptions<DBAccess> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasNoKey();
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
