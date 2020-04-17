using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DALInvemtory.Models.Mapping;

namespace DALInvemtory.Models
{
    public partial class InventoryDBContext : DbContext
    {
        static InventoryDBContext()
        {
            Database.SetInitializer<InventoryDBContext>(null);
        }

        public InventoryDBContext()
            : base("Name=InventoryDBContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
