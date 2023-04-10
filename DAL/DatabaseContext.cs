using Shared;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class DatabaseContext : DbContext
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		   : base(options)
		{
			Database.EnsureCreated();
		}


		DbSet<Models.Answer> Answers { get; set; }

		DbSet<Models.Banner> Banners { get; set; }

		DbSet<Models.Blog> Blogs { get; set; }

		DbSet<Models.Comment> Comments { get; set; }

		DbSet<Models.Contact> Contacts { get; set; }

		DbSet<Models.File> Files { get; set; }

		DbSet<Models.Message> Messages { get; set; }

		DbSet<Models.Product> Products { get; set; }

		DbSet<Models.ProductCategory> ProductCategories { get; set; }

		DbSet<Models.Question> Questions { get; set; }

		DbSet<Models.Role> Roles { get; set; }

		DbSet<Models.Slider> Sliders { get; set; }

		DbSet<Models.User> Users { get; set; }

		DbSet<Models.WishListProduct> WishListProducts { get; set; }

		DbSet<Models.VirtualTour> VirtualTours { get; set; }

		DbSet<Models.UserLogin> UserLogins { get; set; }

		DbSet<Models.OrderDetail> OrderDetails { get; set; }

		DbSet<Models.Address> Addresses { get; set; }

		DbSet<Models.About> Abouts { get; set; }

		DbSet<Models.Image> Images { get; set; }

		DbSet<Models.Order> Orders { get; set; }

		DbSet<Models.ScientificInfo> ScientificInfos { get; set; }

		DbSet<Models.SequenceNumber> SequenceNumbers { get; set; }

		DbSet<Models.Discount> Discounts { get; set; }

		DbSet<Models.UserDiscount> UserDiscounts { get; set; }

		DbSet<Models.ComparisonProduct> ComparisonProducts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Seed Data
			// ***********
			var role =
				new Models.Role()
				{
					Name = "Developer",
				};

			modelBuilder.Entity<Models.Role>().HasData(data: role);

			string password = "Fidar@123";

			var user =
				new Models.User()
				{
					IsActive = true,
					Gender = Domain.Enums.Gender.Female,
					Username = "developer",
					EmailAddress = "info@fidarafzar.ir",
					Password = password.Encode(),
					RoleId = role.Id,
				};

			modelBuilder.Entity<Models.User>().HasData(data: user);
			// *********** 

			// *********** 
			var firstModel =
				new Models.SequenceNumber()
				{
					Name = "TracingCode",
					Number = 1,
				};

			modelBuilder.Entity<Models.SequenceNumber>().HasData(data: firstModel);

			var seconcModel =
				new Models.SequenceNumber()
				{
					Name = "RegisterDiscount",
					Number = 1,
				};

			modelBuilder.Entity<Models.SequenceNumber>().HasData(data: seconcModel);
			// *********** 
			#endregion
		}
	}
}
