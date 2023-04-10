using DAL;
using ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class BlogComponent : ViewComponent
    {
        private const string BlogViewName = "~/Views/Blogs/Index.cshtml";

        public BlogComponent(IUnitOfwork unitOfWork) : base()
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

                var indexViewModels = new List<IndexViewModel>();

                if (foundedBlogs.Any())
                {
                    indexViewModels.AddRange(collection: foundedBlogs.Select(item => new IndexViewModel
                    {
                        BlogId = item.Id,
                        InsertDateTime = item.UpdateDateTime,
                        Title = item.Title,
                        Text = item.Text,
                        Summary = item.Summary,
                        ImageBlogName = item.File.Name,
                    }));

                    return View(viewName: BlogViewName, model: indexViewModels);
                }
                else
                    return View(viewName: BlogViewName, model: indexViewModels);
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
