namespace Models
{
    public class OrderDetail : Domain.Base.Entity
    {
        public OrderDetail()
        {
        }

        public OrderDetail(Product product) : base()
        {
            ProductId = product.Id;
            ProductName = product.Title ?? "";
            ProductPrice = product.Price;
            ProductDiscountedPrice = product.DiscountedPrice;
            ProductDiscountPercentage = product.DiscountPercentage;
            ProductHasDiscount = product.HasDiscount;
            Count = 1;
            if (product.Files != null)
                ProductImage = product.Files.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault() ?? "";
        }
        //**********
        public string? OrderNumber { get; set; }
        //**********

        //**********
        public int Count { get; set; }
        //**********

        //**********
        public double ProductPrice { get; set; }
        //**********

        //**********
        public bool ProductHasDiscount { get; set; }
        //**********

        //**********
        public double ProductDiscountedPrice { get; set; }
        //**********

        //**********
        public double ProductDiscountPercentage { get; set; }
        //**********

        //**********
        public string? ProductImage { get; set; }
        //**********

        //**********
        public string? ProductName { get; set; }
        //**********

        //**********
        public double Total { get; set; }
        //**********

        //**********
        public string? Cupon { get; set; }
        //**********

        #region Relation One To Many with Order
        //**********
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Order))]
        public System.Guid OrderId { get; set; }

        public virtual Models.Order? Order { get; set; }
        //**********
        #endregion

        #region Relation One To Many with Product
        //**********
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Product))]
        public System.Guid ProductId { get; set; }

        public virtual Models.Product? Product { get; set; }
        //**********
        #endregion
    }
}
