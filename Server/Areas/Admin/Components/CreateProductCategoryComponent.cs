using ViewModels.AdminViewModels.ProductCategories;

namespace Server.Areas.Admin.Components
{
	public class CreateProductCategoryComponent : Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private const string ProductCategoryView = "~/Areas/Admin/Views/ProductCategory/Create.cshtml";

		public CreateProductCategoryComponent(DAL.IUnitOfwork unitOfWork) : base()
		{
			UnitOfWork = unitOfWork;
		}

		public DAL.IUnitOfwork UnitOfWork { get; set; }

		public Microsoft.AspNetCore.Mvc.IViewComponentResult Invoke()
		{
			try
			{
				return View(viewName: ProductCategoryView, model: new CreateViewModel());
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
	}
}
