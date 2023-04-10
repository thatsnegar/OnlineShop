namespace ViewModels.ProductCategories
{
    public class ProductCategoriesNavbarViewModel : object
    {
        public ProductCategoriesNavbarViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        public string? Title { get; set; }
        //**********


        //**********
        public List<ViewModels.Products.ProductsNavbarViewModel>? ProductsNavbarViewModel { get; set; }
        //**********
    }
}
