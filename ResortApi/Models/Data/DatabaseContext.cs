using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ResortApi.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SecurityUser> SecurityUsers { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<FoodDrink> FoodDrinks { get; set; }
        public DbSet<FdImg> FdImgs { get; set; }
        public DbSet<FdCategory> FdCategories { get; set; }


        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<AccommodationImg> AccommodationImgs { get; set; }


        public DbSet<HouseBooking> HouseBookings { get; set; }
        public DbSet<HBOrderItem> HBOrderItems { get; set; }
        public DbSet<HBOrder> HBOrders{ get; set; }





        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Serve>Services { get; set; }
        public DbSet<ServeType> ServiceTypes { get; set; }
        public DbSet<ServeImg> ServiceImgs { get; set; }


        public DbSet<ServeCart> ServeCarts { get; set; }
        public DbSet<ServeOrder> ServeOrders { get; set; }
        public DbSet<ServeOrderItem> ServeOrdersItem { get; set; }


        public DbSet<Information> Information { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<FoodDrink>().HasMany(a => a.FdImg).GetInfrastructure().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Role>()
               .HasData(
                   new Role { RoleId = "1", RoleName = "User",RoleIsused = "1", CreateData = DateTime.Now },
                   new Role { RoleId = "2", RoleName = "Admin", RoleIsused = "1", CreateData = DateTime.Now }
               );

            builder.Entity<FdCategory>()
            .HasData(
                new FdCategory { FdCategoryId = "1", Name = "แกง-ต้ม", IsUsed = 1, DateTime = DateTime.Now },
                new FdCategory { FdCategoryId = "2", Name = "ของทอด-ผัด", IsUsed = 1, DateTime = DateTime.Now },
                new FdCategory { FdCategoryId = "3", Name = "ยำ-สลัด", IsUsed = 1, DateTime = DateTime.Now },
                new FdCategory { FdCategoryId = "4", Name = "ของหวาน", IsUsed = 1, DateTime = DateTime.Now },
                new FdCategory { FdCategoryId = "5", Name = "เครื่องดื่ม", IsUsed = 1, DateTime = DateTime.Now },
                new FdCategory { FdCategoryId = "6", Name = "อื่นๆ", IsUsed = 1, DateTime = DateTime.Now }



            );

            builder.Entity<AccommodationType>()
            .HasData(
                new AccommodationType { AccommodationTypeId = "1", Name = "บ้านเดี่ยว", IsUsed = 1, DateTime = DateTime.Now },
                new AccommodationType { AccommodationTypeId = "2", Name = "บ้าน2ชั้น", IsUsed = 1, DateTime = DateTime.Now },
                new AccommodationType { AccommodationTypeId = "3", Name = "อาคารตึก", IsUsed = 1, DateTime = DateTime.Now },
                new AccommodationType { AccommodationTypeId = "4", Name = "บ้านแพ", IsUsed = 1, DateTime = DateTime.Now },
                new AccommodationType { AccommodationTypeId = "5", Name = "พื้นที่กางเต็น", IsUsed = 1, DateTime = DateTime.Now },
                new AccommodationType { AccommodationTypeId = "6", Name = "อื่นๆ", IsUsed = 1, DateTime = DateTime.Now }



            );

            //    builder.Entity<CommunityGroup>()
            //    .HasData(

            //        new CommunityGroup { ID = 1, CommunityGroupName = "เอกชัย", District = "เมือง", SubDistrict = "ท่าระหัด" },
            //        new CommunityGroup { ID = 2, CommunityGroupName = "ตลาดอู่ทอง", District = "อู่ทอง", SubDistrict = "อู่ทอง" }
            //    );
            //    builder.Entity<LevelRarity>()
            //   .HasData(
            //       new LevelRarity { ID = 1, LevelRarityName = "หาได้ทั่วไป", Date = DateTime.Now },
            //       new LevelRarity { ID = 2, LevelRarityName = "ปานกลาง", Date = DateTime.Now },
            //       new LevelRarity { ID = 3, LevelRarityName = "หายาก", Date = DateTime.Now }
            //   );
            //    builder.Entity<StatusAddress>()
            //.HasData(
            //    new StatusAddress { ID = 1, Name = "เป็นได้เเค่พี่น้อง" },
            //    new StatusAddress { ID = 2, Name = "เป็นได้เเค่เพื่อน" }
            //    );

        }



    }
}
