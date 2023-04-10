using DAL;
using ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class RecentBlogComponent : ViewComponent
    {
        private const string RecentBlogViewName = "~/Views/Blogs/RecentBlogs.cshtml";

        public RecentBlogComponent(IUnitOfwork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
        }

        protected DAL.IUnitOfwork UnitOfWork { get; }

        // **************************************************
        // **************************************************


        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var foundedBlogs =
                    await UnitOfWork.Blogs.GetAllBlogsIndexViewAsync();

                var viewModels = new List<ViewModels.Blogs.RecentBlogViewModel>();

                if (foundedBlogs.Any())
                {
                    viewModels.AddRange(collection: foundedBlogs.OrderByDescending(current => current.InsertDateTime).Take(count: 5).Select(item => new RecentBlogViewModel
                    {
                        BlogId = item.Id,
                        InsertDateTime = item.UpdateDateTime,
                        Title = item.Title,
                        ImageBlogName = item.File.Name,
                    }));

                    return View(viewName: RecentBlogViewName, model: viewModels);
                }
                else
                    return View(viewName: RecentBlogViewName, model: viewModels);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
