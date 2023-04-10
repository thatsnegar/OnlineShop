namespace DAL
{
	public interface IUnitOfwork : Base.IUnitOfWork
	{
		// **********
		IAddressRepository Addresses { get; }
		// **********

		// **********
		IFileRepository Files { get; }
		// **********

		// **********
		IProductRepository Products { get; }
		// **********

		// **********
		IProductCategoryRepository ProductCategories { get; }
		// **********

		// **********
		IRoleRepository Roles { get; }
		// **********

		// **********
		ISliderRepository Sliders { get; }
		// **********

		// **********
		IUserRepository Users { get; }
		// **********

		// **********
		IWishListProductRepository WishListProducts { get; }
		// **********

		// **********
		IUserLoginRepository UserLogins { get; }
		// **********

		// **********
		IOrderDetailsRepository OrderDetails { get; }
		// **********

		// **********
		IAboutRepository Abouts { get; }
		// **********

		// **********
		IImageRepository Images { get; }
		// **********

		// **********
		IOrderRepository Orders { get; }
		// **********

		// **********
		ISequenceNumberRepository SequenceNumbers { get; }
		// **********

		// **********
		IDiscountRepository Discounts { get; }
		// **********

		// **********
		IUserDiscountRepository UserDiscounts { get; }
		// **********
	}
}
