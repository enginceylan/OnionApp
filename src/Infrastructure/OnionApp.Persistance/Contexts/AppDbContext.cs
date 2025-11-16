using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Entities;
using OnionApp.Domain.Entities.Identity;
using System.Reflection;
using System.Text.Json;

namespace OnionApp.Persistance.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        // Senden bir nesne oluşturulmaya çalışıldığında mecburen bu constr kullanılacak, sen de DbContextOptions isteyeceksin, bu nesneyi sana IoC verecek, işte connstr falan hepsi onun içinde
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }


        // migraiton ile entity modeli veritabanına aktarılırken, herbir entity için özel konfigurasyon ayarlamalarının uygulandığı metod.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserClaim<int>>();
            builder.Ignore<IdentityRoleClaim<int>>();
            builder.Ignore<IdentityUserToken<int>>();
            builder.Ignore<IdentityUserLogin<int>>();
            //builder.Ignore<IdentityUserRole<int>>();

            //--------------------------------------------------------

            //builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new SupplierConfiguration());

            // Yukarıdaki gibi konfigleri ayrı ayrıo verebileceğimiz gibi aşağıdaki gibi tek satırda da buldurabiliriz : 
            //----------------------------------------------------------

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        #region SEED METHODS
        public async Task SeedAsync()
        {

            // bu metod içerisinde, oluşan veritabanımızın tablolarına veri de eklenmesini sağlayacağız. Bu veriler, uygulama ayağa kalktığında , oluşan veritabanı kontrol edilerek eğer içerisinde başlangıç verisi yerleştirilmemişse , eklenecek

            // Bu metod, uygulama ayağa kalktığında çağrılıp çalıştırılacak.

            await SeedCategories();
            await SeedSuppliers();
            await SeedProducts();
            await SeedOrders();
            await SeedOrderDetails();

        }
        private async Task SeedCategories()
        {
            if (!await Categories.AnyAsync())
            {
                var dir = Path.GetDirectoryName(Environment.CurrentDirectory).Replace("Presentation", "") + "Infrastructure\\OnionApp.Persistance";
                var path = Path.Combine(dir, "Seed", "categories.json");

                var seedDataJson = File.ReadAllText(path);
                var seedData = JsonSerializer.Deserialize<List<Category>>(seedDataJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                using (var transaction = await Database.BeginTransactionAsync())
                {
                    await Database.ExecuteSqlRawAsync("set identity_insert Categories on");

                    Categories.AddRange(seedData);
                    await SaveChangesAsync();

                    await Database.ExecuteSqlRawAsync("set identity_insert Categories off");

                    await transaction.CommitAsync();
                }


            }
        }
        private async Task SeedSuppliers()
        {
            if (!await Suppliers.AnyAsync())
            {
                var dir = Path.GetDirectoryName(Environment.CurrentDirectory).Replace("Presentation", "") + "Infrastructure\\OnionApp.Persistance";
                var path = Path.Combine(dir, "Seed", "suppliers.json");

                var seedDataJson = File.ReadAllText(path);
                var seedData = JsonSerializer.Deserialize<List<Supplier>>(seedDataJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                using (var transaction = await Database.BeginTransactionAsync())
                {
                    await Database.ExecuteSqlRawAsync("set identity_insert Suppliers on");

                    Suppliers.AddRange(seedData);
                    await SaveChangesAsync();

                    await Database.ExecuteSqlRawAsync("set identity_insert Suppliers off");

                    await transaction.CommitAsync();
                }


            }
        }
        private async Task SeedProducts()
        {
            if (!await Products.AnyAsync()) // eğer tabloda hiç veri yoksa
            {
                var dir = Path.GetDirectoryName(Environment.CurrentDirectory).Replace("Presentation", "") + "Infrastructure\\OnionApp.Persistance";
                var path = Path.Combine(dir, "Seed", "products.json");

                var seedDataJson = File.ReadAllText(path);
                var seedData = JsonSerializer.Deserialize<List<Product>>(seedDataJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                using (var transaction = await Database.BeginTransactionAsync())
                {
                    await Database.ExecuteSqlRawAsync("set identity_insert Products on");

                    Products.AddRange(seedData);
                    await SaveChangesAsync();

                    await Database.ExecuteSqlRawAsync("set identity_insert Products off");

                    await transaction.CommitAsync();
                }


            }
        }
        private async Task SeedOrders()
        {
            if (!await Orders.AnyAsync())
            {
                var dir = Path.GetDirectoryName(Environment.CurrentDirectory).Replace("Presentation", "") + "Infrastructure\\OnionApp.Persistance";
                var path = Path.Combine(dir, "Seed", "orders.json");

                var seedDataJson = File.ReadAllText(path);
                var seedData = JsonSerializer.Deserialize<List<Order>>(seedDataJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                using (var transaction = await Database.BeginTransactionAsync())
                {
                    await Database.ExecuteSqlRawAsync("set identity_insert Orders on");

                    Orders.AddRange(seedData);
                    await SaveChangesAsync();

                    await Database.ExecuteSqlRawAsync("set identity_insert Orders off");

                    await transaction.CommitAsync();
                }


            }
        }
        private async Task SeedOrderDetails()
        {
            if (!await OrderDetails.AnyAsync())
            {
                var dir = Path.GetDirectoryName(Environment.CurrentDirectory).Replace("Presentation", "") + "Infrastructure\\OnionApp.Persistance";
                var path = Path.Combine(dir, "Seed", "orderdetails.json");

                var seedDataJson = File.ReadAllText(path);
                var seedData = JsonSerializer.Deserialize<List<OrderDetail>>(seedDataJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                using (var transaction = await Database.BeginTransactionAsync())
                {
                    //await Database.ExecuteSqlRawAsync("set identity_insert OrderDetails on");

                    OrderDetails.AddRange(seedData);
                    await SaveChangesAsync();

                    //await Database.ExecuteSqlRawAsync("set identity_insert OrderDetails off");

                    await transaction.CommitAsync();
                }


            }
        }

        #endregion

    }
}
