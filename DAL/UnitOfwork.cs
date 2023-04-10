namespace DAL
{
	public class UnitOfwork : Base.UnitOfWork, IUnitOfwork
	{
		public UnitOfwork(Tools.Options options) : base(options)
		{
		}

		// **************************************************
		// **************************************************
		private IAddressRepository? _addresses;

		public IAddressRepository Addresses
		{
			get
			{
				if (_addresses == null)
				{
					_addresses =
						new AddressRepository(DatabaseContext);
				}

				return _addresses;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IFileRepository? _files;

		public IFileRepository Files
		{
			get
			{
				if (_files == null)
				{
					_files =
						new FileRepository(DatabaseContext);
				}
				return _files;
			}
		}
		// **************************************************
		// **************************************************

		
		// **************************************************
		// **************************************************
		private IProductRepository? _products;

		public IProductRepository Products
		{
			get
			{
				if (_products == null)
				{
					_products =
						new ProductRepository(DatabaseContext);
				}

				return _products;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IProductCategoryRepository? _productCategories;

		public IProductCategoryRepository ProductCategories
		{
			get
			{
				if (_productCategories == null)
				{
					_productCategories =
						new ProductCategoryRepository(DatabaseContext);
				}

				return _productCategories;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		private IRoleRepository? _roles;

		public IRoleRepository Roles
		{
			get
			{
				if (_roles == null)
				{
					_roles =
						new RoleRepository(DatabaseContext);
				}

				return _roles;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private ISliderRepository? _sliders;

		public ISliderRepository Sliders
		{
			get
			{
				if (_sliders == null)
				{
					_sliders =
						new SliderRepository(DatabaseContext);
				}

				return _sliders;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IUserRepository? _users;

		public IUserRepository Users
		{
			get
			{
				if (_users == null)
				{
					_users =
						new UserRepository(DatabaseContext);
				}

				return _users;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IWishListProductRepository? _wishListProducts;

		public IWishListProductRepository WishListProducts
		{
			get
			{
				if (_wishListProducts == null)
				{
					_wishListProducts =
						new WishListProductRepository(DatabaseContext);
				}

				return _wishListProducts;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IUserLoginRepository? _userLogins;

		public IUserLoginRepository UserLogins
		{
			get
			{
				if (_userLogins == null)
				{
					_userLogins =
						new UserLoginRepository(DatabaseContext);
				}

				return _userLogins;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IOrderDetailsRepository? _orderDetails;

		public IOrderDetailsRepository OrderDetails
		{
			get
			{
				if (_orderDetails == null)
				{
					_orderDetails =
						new OrderDetailsRepository(DatabaseContext);
				}

				return _orderDetails;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IAboutRepository? _abouts;

		public IAboutRepository Abouts
		{
			get
			{
				if (_abouts == null)
				{
					_abouts =
						new AboutRepository(DatabaseContext);
				}

				return _abouts;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IImageRepository? _images;

		public IImageRepository Images
		{
			get
			{
				if (_images == null)
				{
					_images =
						new ImageRepository(DatabaseContext);
				}

				return _images;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IOrderRepository? _orders;

		public IOrderRepository Orders
		{
			get
			{
				if (_orders == null)
				{
					_orders =
						new OrderRepository(DatabaseContext);
				}

				return _orders;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private ISequenceNumberRepository? _sequenceNumbers;

		public ISequenceNumberRepository SequenceNumbers
		{
			get
			{
				if (_sequenceNumbers == null)
				{
					_sequenceNumbers =
						new SequenceNumberRepository(DatabaseContext);
				}

				return _sequenceNumbers;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IDiscountRepository? _discounts;

		public IDiscountRepository Discounts
		{
			get
			{
				if (_discounts == null)
				{
					_discounts =
						new DiscountRepository(DatabaseContext);
				}

				return _discounts;
			}
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		private IUserDiscountRepository? _userDiscounts;

		public IUserDiscountRepository UserDiscounts
		{
			get
			{
				if (_userDiscounts == null)
				{
					_userDiscounts =
						new UserDiscountRepository(DatabaseContext);
				}

				return _userDiscounts;
			}
		}
		// **************************************************
		// **************************************************
		
	}
}

