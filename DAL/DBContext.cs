using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DBContext : DbContext 
    {
        //private string _connectionString = "Data Source=DESKTOP-KMQSLVI\\SQLEXPRESS;Initial Catalog=practico1;" +
        //"Persist Security Info=True;User ID=sa;Password=UTEC;Encrypt=False";
        //puerto 1433

        private string _connectionString = "Server=sqlserver,1433;Database=practico1;User Id=sa;Password=Abc*123!;Encrypt=False;";
        public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }

        public static void UpdateDatabase()
        {
            using (var context = new DBContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
