using DAL;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Server.Controllers
{
    public class BlogsController : Infrastructure.BaseControllerWithDatabase
    {

        public BlogsController(ILogger<HomeController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
            Logger = logger;
        }

        public ILogger<HomeController> Logger { get; }

        // **************************************************
        // **************************************************

        public IActionResult Test()
        {
            return View();
        }

        public async Task<IActionResult> BlogsList(int pageNumber = 1)
        {
            try
            {
                var foundedUser =
                GetCurrentUser();

                ViewData["foundedOnlineUser"] = foundedUser;

                var foundedBlogs =
                    await UnitOfWork.Blogs.GetAllBlogsAsync();

                var viewModels = new List<ViewModels.Blogs.BlogViewModel>();

                if (foundedBlogs.Any())
                {
                    // Page Number
                    ViewBag.PageNumber = pageNumber;

                    var pageViewModel =
                        new ViewModels.Paginations.PageViewModel(pageNumber: pageNumber);

                    var totalPages =
                        ((double)foundedBlogs.Count / (double)pageViewModel.PageSize);

                    int roundedTotalPages =
                        Convert.ToInt32(Math.Ceiling(a: totalPages));

                    // Total Pages
                    ViewBag.TotalPages =
                        roundedTotalPages;

                    foundedBlogs =
                        foundedBlogs
                        .Skip(count: (pageViewModel.PageNumber - 1) * pageViewModel.PageSize)
                        .Take(count: pageViewModel.PageSize)
                        .ToList()
                        ;

                    viewModels.AddRange(collection: foundedBlogs.Select(item => new ViewModels.Blogs.BlogViewModel
                    {
                        BlogId = item.Id,
                        InsertDateTime = item.UpdateDateTime,
                        Title = item.Title,
                        Text = item.Text,
                        Summary = item.Summary,
                        ImageBlogName = item.File.Name,
                    }));

                    return View(model: viewModels);
                }
                else
                {
                    // Logger
                    return View(model: viewModels);
                }
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var foundedUser =
                    GetCurrentUser();

                ViewData["foundedOnlineUser"] = foundedUser;

                var foundedBlog =
                    await UnitOfWork.Blogs.GetBlogByIdAsync(id: id);


                if (foundedBlog is not null)
                {
                    var viewModel = new ViewModels.Blogs.DetailViewModel()
                    {
                        Title = foundedBlog.Title,
                        InsertDateTime = foundedBlog.UpdateDateTime,
                        Text = foundedBlog.Text,
                        ImageBlogName = foundedBlog.File.Name,
                    };

                    return View(model: viewModel);
                }
                else
                {
                    // Logger
                    return NotFound();
                }
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
