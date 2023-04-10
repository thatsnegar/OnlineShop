using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class CreateAddressComponent : ViewComponent
    {
        private const string CreateAddressViewName = "~/Views/Address/Create.cshtml";

        public CreateAddressComponent() : base()
        {
        }

        // **************************************************
        // **************************************************

        public IViewComponentResult Invoke()
        {
            try
            {
                return View(viewName: CreateAddressViewName, model: new ViewModels.Addresses.CreateAddressViewModel());
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
