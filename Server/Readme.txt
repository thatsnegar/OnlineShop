//***** Navbar *****//
//**************************************************//
The following approach shows how to manage a navbar with one to many relation
with this method we used Dictionary which gets {Key, Value} pair 
After that we defined a common key which here is "Main category"
and then we loop through with and get a list of "Product categories" that has a common main category
//**************************************************//

public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var foundedProductCategories =
                    await UnitOfWork.ProductCategories.GetProductCategoriesActiveAsync();

                if (foundedProductCategories.Any())
                {
                    var productCategoryDictionary =
                        new Dictionary<string, List<ProductCategoriesNavbarViewModel>>();

                    foreach (var item in foundedProductCategories)
                    {
                        if (productCategoryDictionary.ContainsKey(key: item.MainCategory))
                        {
                            var viewModel = 
                                new ProductCategoriesNavbarViewModel()
                            {
                                Id = item.Id,
                                Title = item.Title,
                            };

                            productCategoryDictionary[item.MainCategory].Add(item: viewModel);
                        }
                        else
                        {
                            var productCategoriesNavbar = 
                                new List<ProductCategoriesNavbarViewModel>();

                             var productCategoryNavbar = 
                                new ProductCategoriesNavbarViewModel
                             {
                                Id = item.Id,
                                Title = item.Title,
                            };

                            productCategoriesNavbar.Add(item: productCategoryNavbar);

                            productCategoryDictionary.Add(key: item.MainCategory, value: productCategoriesNavbar);
                        }
                    }

                    return View(viewName: NavbarViewName, model: productCategoryDictionary);
                }
                else
                {
                //**************************************************//
                build a new list then!
                //**************************************************//

                    var productCategoryDictionary =
                        new Dictionary<string, List<ProductCategoriesNavbarViewModel>>();

                    return View(viewName: NavbarViewName, model: productCategoryDictionary);
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

 //**************************************************//
 //**************************************************//
    // **************************************************//
    build a new list then!
    // **************************************************//

    // First Solution
    indexViewModels.AddRange(collection: foundedProducts.Select(item => new IndexViewModel
    {
                         
    }));

    // Second Solution
    foreach (var item in foundedProducts)
    {
        // Solution(1)
        var indexViewModel = new IndexViewModel
        {

        };

        indexViewModels.Add(indexViewModel);

        // Solution(2)
        indexViewModel.Add(new IndexViewModel{});
    }
 //**************************************************//
 //**************************************************//
    //**************************************************//
        Watch for Edit
    //**************************************************//

 var errors =
     ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

//**************************************************//
//**************************************************//

https://codepen.io/Coding-in-Public/pen/NWyjZwO

https://github.com/jotform/before-after.js/blob/master/before-after.css

//**************************************************//
//**************************************************//

    //**************************************************//
     How to get Random Number in C#
    //**************************************************//

var getNewRandomNumber = new Random().Next(1, 10).ToString();

//**************************************************//
//**************************************************//

    //**************************************************//
     Anonymous Type Object
    //**************************************************//

RedirectToAction("ActivateMobile", "Account", new { mobile = register.Mobile });

public IActionResult ActivateMobile(string mobile);

//**************************************************//
//**************************************************//

    //**************************************************//
    How to Add to Cart
    //**************************************************//

<partial name="_AddProductToCartPartial" model="@(new AddProductToOrderDTO{Count = 1, ProductId = Model.ProductId})" />

<form method="post"
      asp-area="User"
      asp-controller="Order"
      asp-action="AddProductToOrder"
      data-ajax="true"
      data-ajax-success="onSuccessAddProductToOrder"
      data-ajax-method="post"
      id="addProductToOrderForm"
      >
    <input type="hidden" id="add_product_to_order_ProductId" asp-for="ProductId" />
    <input type="hidden" asp-for="ProductColorId" id="add_product_to_order_ProductColorId" />
    <input type="hidden" asp-for="Count" id="add_product_to_order_Count" />
</form>

<button class="button" type="submit" id="submitOrderForm">افزودن به سبد</button>

$('#submitOrderForm').on('click', function () {
    $('#addProductToOrderForm').submit();
});

Unobstrasive JS is Required!

//**************************************************//
//**************************************************//

To skip validating a property in our models use => [ValidateNever]

//**************************************************//
//**************************************************//

**************************************************
**************************************************

//----------------------
Get Enum Value
//----------------------

Enum.GetValues(typeof(Domain.Enums.Gender)).Cast<Domain.Enums.Gender>().ToList();

**************************************************
**************************************************

1 -> Install Nuget:
    1. Parbad
    2. Parbad.AspNetCore

2 -> Configuration:
        StartUp => ConfigureServices => services.AddParbad().ConfigureGateway(gateways => 
        {
            gateways.AddMellat().WithAccounts(accounts => 
            {
                accounts.AddInMemory(account => 
                {
                    account.TerminalId = 123;
                    account.Username = "admin";
                    account.UserPassword = "123";
                });
            });

            // Add the Virtual Gateway for Testing
            gateways.AddParbadVirtual().WithOptions(options => options.GatewayPath = "/MyVirtualGateway");
        })
        .ConfigureHttpContext(builder => builder.UseDefaultAspNetCore())
        .ConfigureStorage(builder => builder.UseMemoryCache());

3 -> Enable Virtual Gateway in Configure:
        app.UseParbadVirtualGateway();

4 -> Payment:
        1. DI => IOnlinePayment
        2. Add Action PaymentAsync => 

            var callbackUrl = 
                Url.Action("Verify", "Home", null, Request.Scheme);

            var result = 
                await OnlinePayment.RequestAsync(invoice => 
            {
                invoice
                .SetTrackingNumber(1000)
                .SetAmount(2500)
                .SetCallbackUrl(callbackUrl)
                .UseGateway(Gateway.ParbadVirtualGateway)
                ;   
            });

            // Don't Forget the Save Result's Information in Your Database

            if(result.IsSuccess)
            {
                return result.GatewayTransporter.TransportToGateway();
            }

            return View("Error", result);

        3. Add Action VerifyAsync => 
            
            var result = await OnlinePayment.VerifyAsync(invoice => 
            {
                if(!IsEverythingOk(invoice.TrackingNumber))
                {
                    invoice.CancelPayment();
                }
            })

            // Don't Forget the Save Result's Information in Your Database

            return View(result);

        4. Add bool IsEverythingOK(long trackingNumber) =>
            return true;

        5. Add Verify View 
            @model Parbad.IPaymentVerifyResult

            @Model.TrackingNumber

            @Model.IsSucceed

            @Model.Amount

            @Model.TransactionCode

            @Model.GatewayName

            @Model.GatewayAccountName

            @Model.Message

https://www.youtube.com/watch?v=zGGpf-Csj8Y
https://www.dntips.ir/post/3011/%d9%be%d8%b1%d8%a8%d8%a7%d8%af-%d8%a2%d9%85%d9%88%d8%b2%d8%b4-%d9%be%db%8c%d8%a7%d8%af%d9%87%e2%80%8c%d8%b3%d8%a7%d8%b2%db%8c-%d9%be%d8%b1%d8%af%d8%a7%d8%ae%d8%aa-%d8%a2%d9%86%d9%84%d8%a7%db%8c%d9%86-%d8%af%d8%b1-%d8%af%d8%a7%d8%aa-%d9%86%d8%aa-%d8%a2%d9%85%d9%88%d8%b2%d8%b4-%d9%be%d8%a7%db%8c%d9%87
https://barnamenevis.org/showthread.php?549844-%D9%BE%D9%8E%D8%B1%D8%A8%D8%A7%D8%AF-%D8%B1%D8%A7%D9%87%D9%86%D9%85%D8%A7%DB%8C-%D8%A7%D8%AA%D8%B5%D8%A7%D9%84-%D9%88-%D9%BE%DB%8C%D8%A7%D8%AF%D9%87%E2%80%8C%D8%B3%D8%A7%D8%B2%DB%8C-%D8%AF%D8%B1%DA%AF%D8%A7%D9%87%E2%80%8C%D9%87%D8%A7%DB%8C-%D9%BE%D8%B1%D8%AF%D8%A7%D8%AE%D8%AA-%D8%A7%DB%8C%D9%86%D8%AA%D8%B1%D9%86%D8%AA%DB%8C-(%D8%B4%D8%A8%DA%A9%D9%87-%D8%B4%D8%AA%D8%A7%D8%A8)       


