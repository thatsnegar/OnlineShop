namespace DAL
{
	public interface IUnitOfwork : Base.IUnitOfWork
	{
		// **********
		IAddressRepository Addresses { get; }
		// **********

		// **********
		IAnswerRepository Answers { get; }
		// **********

		// **********
		IBannerRepository Banners { get; }
		// **********

		// **********
		IBlogRepository Blogs { get; }
		// **********

		// **********
		ICommentRepository Comments { get; }
		// **********

		// **********
		IContactRepository Contacts { get; }
		// **********

		// **********
		IFileRepository Files { get; }
		// **********

		// **********
		IMessageRepository Messages { get; }
		// **********

		// **********
		IProductRepository Products { get; }
		// **********

		// **********
		IProductCategoryRepository ProductCategories { get; }
		// **********

		// **********
		IQuestionRepository Questions { get; }
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
		IVirtualTourRepository VirtualTours { get; }
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
		IScientificInfoRepository ScientificInfos { get; }
		// **********

		// **********
		IDiscountRepository Discounts { get; }
		// **********

		// **********
		IUserDiscountRepository UserDiscounts { get; }
		// **********

		// **********
		IComparisonProductRepository ComparisonProducts { get; }
		// **********
	}
}
