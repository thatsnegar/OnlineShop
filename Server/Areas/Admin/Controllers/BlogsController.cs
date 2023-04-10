using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Blogs;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class BlogsController : Infrastructure.BaseControllerWithDataBase
    {
        public BlogsController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
        {
            FilesService = filesService;
        }

        protected Services.IFilesService FilesService { get; }

        // **************************************************
        // **************************************************

        // GET: Admin/Blog
        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var indexViewModel = new List<IndexViewModel>();

                var foundedBlogs =
                    await UnitOfWork.Blogs.GetAllBlogsAsync();

                if (foundedBlogs.Any())
                {
                    indexViewModel.AddRange(collection: foundedBlogs.Select(item => new IndexViewModel
                    {
                        Id = item.Id,
                        IsEditted = item.IsEdited,
                        InsertDateTime = item.InsertDateTime,
                        UpdateDateTime = item.UpdateDateTime,
                        Title = item.Title,
                        ShowInIndex = item.ShowInIndex,
                    }));

                    return View(model: indexViewModel);
                }
                else
                    return View(model: indexViewModel);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // GET: Admin/Blog/Create
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

        #endregion

        // POST: Admin/Blogs/Create
        #region Blogs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (viewModel.Text is null)
                    {
                        ModelState.AddModelError(key: nameof(viewModel.Text), "وارد کردن متن وبلاگ اجباری می باشد.");
                    }

                    return View(model: viewModel);
                }

                if (viewModel.ImageBlog is null)
                {
                    // Insert Blog
                    var model = new Blog
                    {
                        Title = viewModel.Title,
                        Text = viewModel.Text,
                        Summary = viewModel.Summary,
                    };

                    await UnitOfWork.Blogs.InsertAsync(entity: model);

                    await UnitOfWork.SaveAsync();

                    return RedirectToAction(actionName: "Index", controllerName: "Blogs");
                }
                else
                {
                    #region Add File
                    Models.File uploadFile =
                        await FilesService.UploadFileAsync(file: viewModel.ImageBlog, folder: "Blogs");
                    #endregion

                    if (uploadFile is not null)
                    {
                        // Insert Blog
                        var model = new Blog
                        {
                            Title = viewModel.Title,
                            Text = viewModel.Text,
                            Summary = viewModel.Summary,
                            File = uploadFile,
                        };

                        await UnitOfWork.Blogs.InsertAsync(entity: model);

                        //Insert File 
                        uploadFile.Blog = model;
                        uploadFile.BlogId = model.Id;
                        await UnitOfWork.Files.InsertAsync(entity: uploadFile);

                        await UnitOfWork.SaveAsync();

                        return RedirectToAction(actionName: "Index", controllerName: "Blogs");
                    }
                    else
                    {
                        // Logger
                        return View(model: viewModel);
                    }
                }
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // GET: Admin/Blogs/Edit
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var foundedBlog =
                    await UnitOfWork.Blogs.GetBlogByIdAsync(id: id);

                if (foundedBlog is null)
                {
                    // Logger
                    return NotFound();
                }

                var viewModel = new ViewModels.AdminViewModels.Blogs.EditViewModel
                {
                    Id = foundedBlog.Id,
                    Title = foundedBlog.Title,
                    Text = foundedBlog.Text,
                    Summary = foundedBlog.Summary,
                    ImageBlogName = foundedBlog.File?.Name,
                };

                return View(model: viewModel);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/‌Blogs/Edit
        #region Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedBlog =
                    await UnitOfWork.Blogs.GetBlogByIdAsync(id: viewModel.Id);

                if (foundedBlog is null)
                    return View(model: viewModel);

                if (viewModel.ImageBlog?.Length > 0)
                {
                    if (foundedBlog.File is null)
                    {
                        #region Add File
                        Models.File uploadFile =
                            await FilesService.UploadFileAsync(file: viewModel.ImageBlog, folder: "Blogs");
                        #endregion

                        if (uploadFile is not null)
                        {
                            //Insert File 
                            uploadFile.BlogId = foundedBlog.Id;
                            await UnitOfWork.Files.InsertAsync(entity: uploadFile);
                        }
                        else
                        {
                            // Logger
                            return NotFound(value: "Problem is about Upload New File");
                        }
                    }
                    else
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedBlog.File);

                        if (isDeleteFile)
                        {
                            #region Add File
                            Models.File uploadFile =
                                await FilesService.UploadFileAsync(file: viewModel.ImageBlog, folder: "Blogs");
                            #endregion

                            if (uploadFile is not null)
                            {
                                // Update File
                                foundedBlog.File.Name = uploadFile.Name;
                                foundedBlog.File.ContentType = uploadFile.ContentType;
                                foundedBlog.File.Path = uploadFile.Path;
                                foundedBlog.File.Size = uploadFile.Size;
                                foundedBlog.File.Alt = uploadFile.Alt;
                                UnitOfWork.Files.Update(entity: foundedBlog.File);
                            }
                            else
                            {
                                // Logger
                                return NotFound(value: "Problem is about Upload New File");
                            }
                        }
                        else
                        {
                            // Logger
                            return NotFound(value: "Problem is about Delete Old File");
                        }
                    }
                }

                //Update Blog
                foundedBlog.Title = viewModel.Title;
                foundedBlog.Text = viewModel.Text;
                foundedBlog.Summary = viewModel.Summary;
                UnitOfWork.Blogs.Update(entity: foundedBlog);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Blogs");
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Blogs/Delete
        #region Delete
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                var foundedBlog =
                    await UnitOfWork.Blogs.GetBlogByIdAsync(id: Guid.Parse(id));

                if (foundedBlog is not null)
                {
                    if (foundedBlog.File is not null)
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedBlog.File);

                        if (isDeleteFile)
                            UnitOfWork.Files.Delete(entity: foundedBlog.File);
                    }

                    UnitOfWork.Blogs.Delete(entity: foundedBlog);

                    await UnitOfWork.SaveAsync();

                    result = true;

                    return Json(data: result);
                }
                else
                {
                    //Logger
                    return Json(data: result);
                }
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Products/ConfirmShowInIndex
        #region confirmShowIndex
        [HttpPost]
        public async Task<JsonResult> ConfirmShowInIndex(string id)
        {
            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var guid = Guid.Parse(input: id);

                var foundedBlog =
                    await UnitOfWork.Blogs.GetByIdAsync(id: guid);

                if (foundedBlog is not null)
                {
                    if (foundedBlog.ShowInIndex == false)
                        foundedBlog.ShowInIndex = true;

                    else
                        foundedBlog.ShowInIndex = false;

                    UnitOfWork.Blogs.Update(entity: foundedBlog);
                    await UnitOfWork.SaveAsync();

                    result = true;

                    return Json(data: result);
                }
                else
                    return Json(data: result);
            }

            catch (Exception)
            {
                //Logger
                throw;
            }
        }

        #endregion
    }
}
