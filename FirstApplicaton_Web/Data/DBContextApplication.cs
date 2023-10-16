using FirstApplicaton_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApplicaton_Web.Data

{
    public class DBContextApplication : DbContext
    {
        public DBContextApplication(DbContextOptions<DBContextApplication>options) : base(options) 
        {
        }
        public DbSet<Catagory> Catagories { get; set; }
    }
}
