using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShopOnline.Data.Entities;
using Advertisement = MyShopOnline.Data.Entities.Advertisement;

namespace MyShopOnline.Data
{
    public class MyShopOnlineDbContext: IdentityDbContext<User>
    {


        public MyShopOnlineDbContext()
        {
            //this.Database.EnsureCreated();
        }

        public MyShopOnlineDbContext(DbContextOptions options):base(options)
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
            //this.Database.EnsureDeleted();
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }    
        public DbSet<Status> Statuses { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionStr = "Data Source=DESKTOP-ASTVPAV;" +
                "Initial Catalog=MyShopOnlineMvc;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;" +
                "Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connectionStr);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var decimalProps = modelBuilder.Model
                                 .GetEntityTypes()
                                 .SelectMany(t => t.GetProperties())
                                 .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advertisement>().Property(p => p.Quantity).HasDefaultValue(0);

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category() { ID = 1, Name = "Electronics" },
                new Category() { ID = 2, Name = "Sport" },
                new Category() { ID = 3, Name = "Fashion" },
                new Category() { ID = 4, Name = "Home & Garden" },
                new Category() { ID = 5, Name = "Transport" },
                new Category() { ID = 6, Name = "Toys & Hobbies" },
                new Category() { ID = 7, Name = "Musical Instruments" },
                new Category() { ID = 8, Name = "Art" },
                new Category() { ID = 9, Name = "Other" },
                new Category() { ID = 10,Name = "Car", },
                new Category() { ID = 11,Name = "Animal", },
                new Category() { ID = 12,Name = "Tools", },
            });

            modelBuilder.Entity<State>().HasData(new State[]
            {
                new State() { ID = 1, Name = "New" },
                new State() { ID = 2, Name = "Used" },
                
            });

            

            modelBuilder.Entity<Status>().HasData(new Status[]
{
                new Status() { ID = 1, Name = "Requires approval" },
                new Status() { ID = 2, Name = "Displayed/Active" },
                new Status() { ID = 3, Name = "Hidden/Inactive" },
                new Status() { ID = 4, Name = "Blocked" },
                new Status() { ID = 5, Name = "Under consideration" },
                new Status() { ID = 6, Name = "In processing" },
                new Status() { ID = 7, Name = "In the way" },
                new Status() { ID = 8, Name = "Completed" },
                new Status() { ID = 9, Name = "In the archive" },

            });

            modelBuilder.Entity<Advertisement>().HasData(new[]
            {
                new Advertisement() { ID = 1, Description="Smartphone",   SellerPhone = "0985521562", Quantity = 0, StateId = 1, StatusId = 1 , SellerName = "qweer", Date = new DateTime(2022,10,5), Name = "iPhone X", CategoryId = 1,  Price = 650, ImageUrl = "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png" },
                new Advertisement() { ID = 2, Description="Ball",         SellerPhone = "0985534322", Quantity = 0, StateId = 2, StatusId = 2 , SellerName = "wolf", Date = new DateTime(2023,11,15), Name = "PowerBall", CategoryId = 2, Price = 45.5M, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_727192-CBT53879999753_022023-V.jpg" },
                new Advertisement() { ID = 3, Description="Good t-shirt", SellerPhone = "0984535362", Quantity = 5, StateId = 2, StatusId = 3 , SellerName = "cat", Date = new DateTime(2024,12,25), Name = "Nike T-Shirt", CategoryId = 3,  Price = 189, InStock = true, ImageUrl = "https://www.seekpng.com/png/detail/316-3168852_nike-air-logo-t-shirt-nike-t-shirt.png" },
                new Advertisement() { ID = 4, Description="Smartphone",   SellerPhone = "0984652666", Quantity = 5, StateId = 1, StatusId = 4 , SellerName = "Rivne", Date = new DateTime(2022,1,17), Name = "Samsung S23", CategoryId = 1, Price = 1200, InStock = true, ImageUrl = "https://sota.kh.ua/image/cache/data/Samsung-2/samsung-s23-s23plus-blk-01-700x700.webp" },
                new Advertisement() { ID = 5, Description="Ball",         SellerPhone = "0985527882", Quantity = 0, StateId = 1, StatusId = 5 , SellerName = "urt", Date = new DateTime(2023,2,8), Name = "Air Ball", CategoryId = 6, Price = 50, ImageUrl = "https://cdn.shopify.com/s/files/1/0046/1163/7320/products/69ee701e-e806-4c4d-b804-d53dc1f0e11a_grande.jpg" },
                new Advertisement() { ID = 6, Description="Leptop",       SellerPhone = "0985314523", Quantity = 5, StateId = 1, StatusId = 6 , SellerName = "SellerOut", Date = new DateTime(2024,3,20), Name = "MacBook Pro 2019", CategoryId = 1,  InStock = true, Price = 1200, ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp" },
                new Advertisement() { ID = 7, Description="Leptop",       SellerPhone = "0985314523", Quantity = 5, StateId = 1, StatusId = 6 , SellerName = "SellerOut", Date = new DateTime(2024,3,20), Name = "MacBook Pro 2019", CategoryId = 1,  InStock = true, Price = 1200, ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp" },
                new Advertisement() { ID = 8, Description="Samsung Galaxy Samsung Galaxy",       SellerPhone = "0985314523", Quantity = 9, StateId = 1, StatusId = 1 , SellerName = "SellerOut1", Date = new DateTime(2024,3,20), Name = "Samsung Galaxy", CategoryId = 1,  InStock = true, Price = 800, ImageUrl = "https://scdn.comfy.ua/89fc351a-22e7-41ee-8321-f8a9356ca351/https://cdn.comfy.ua/media/catalog/product/s/m/sm-a245_galaxy_a24_lte_light_green_front.png/w_600" },
                new Advertisement() { ID = 9, Description="Acer Electrical Scooter 5  Acer Electrical Scooter 5",       SellerPhone = "0985314523", Quantity = 5, StateId = 2, StatusId = 1 , SellerName = "SellerOut2", Date = new DateTime(2024,3,20), Name = "Acer Electrical Scooter 5", CategoryId = 10,  InStock = true, Price = 2200, ImageUrl = "https://scdn.comfy.ua/89fc351a-22e7-41ee-8321-f8a9356ca351/https://cdn.comfy.ua/media/catalog/product/e/s/escooter_series_05_gallery_01.jpg/w_600" },
                new Advertisement() { ID = 10, Description="Tefal B817S255 INTUITION 20 /26 ",       SellerPhone = "0985314523", Quantity = 0, StateId = 2, StatusId = 1 , SellerName = "SellerOut2", Date = new DateTime(2024,3,20), Name = "Tefal", CategoryId = 9,  InStock = false, Price = 100, ImageUrl = "https://scdn.comfy.ua/89fc351a-22e7-41ee-8321-f8a9356ca351/https://cdn.comfy.ua/media/catalog/product/_/t/_tefal_b817s255_intuition_20__13.jpg/w_600" },
                new Advertisement() { ID = 11, Description="Tefal Infiny force HB943838",       SellerPhone = "0985314523", Quantity = 10, StateId = 1, StatusId = 1 , SellerName = "SellerOut1", Date = new DateTime(2024,3,20), Name = "Blender ", CategoryId = 9,  InStock = true, Price = 200, ImageUrl = "https://scdn.comfy.ua/89fc351a-22e7-41ee-8321-f8a9356ca351/https://cdn.comfy.ua/media/catalog/product/t/e/tefal_hb943838_2.jpg/w_600" },
            });
        }
    }
}