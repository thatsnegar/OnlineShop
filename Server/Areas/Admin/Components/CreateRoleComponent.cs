using ViewModels.AdminViewModels.Roles;

namespace Server.Areas.Admin.Components
{
    public class CreateRoleComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private const string RoleView = "~/Areas/Admin/Views/Role/Create.cshtml";

        public CreateRoleComponent() : base()
        {
        }

        public Microsoft.AspNetCore.Mvc.IViewComponentResult Invoke()
        {
            try
            {
                var createViewModel = new CreateViewModel();

                return View(viewName: RoleView, model: createViewModel);
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
