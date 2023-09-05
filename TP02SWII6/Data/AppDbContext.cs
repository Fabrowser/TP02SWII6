using Microsoft.EntityFrameworkCore;
using TP02_SWII6.Models;



namespace TP02_SWII6.Data

{
    public class AppDbContext : DbContext
    {

        public DbSet<BL> Bls { get; set; }
        public DbSet<Container> Containers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=TP02;Integrated Security = true");
        }


    }
}
