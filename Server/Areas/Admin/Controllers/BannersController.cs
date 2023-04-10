using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Banners;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class BannersController : Infrastructure.BaseControllerWithDataBase
    {
        public BannersController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
        {
            FilesService = filesService;
        }

        protected Services.IFilesService FilesService { get; }

        // **************************************************
        // **************************************************

        // GET: Admin/Banner
        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var indexViewModel = new List<IndexViewModel>();

                var foundedBanners =
                    await UnitOfWork.Banners.GetAllBannersAsync();

                if (foundedBanners.Any())
                {
                    indexViewModel.AddRange(collection: foundedBanners.Select(item => new IndexViewModel
                    {
                        Id = item.Id,
                        IsEditted = item.IsEdited,
                        InsertDateTime = item.InsertDateTime,
                        UpdateDateTime = item.UpdateDateTime,
                        Title = item.Title,
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

        // GET: Admin/Banner/Create
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View(model: new CreateViewModel());
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

        #endregion

        // POST: Admin/Banners/Create
        #region Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                #region Add File
                if (viewModel.ImageBanner is null)
                    return View(model: viewModel);

                Models.File uploadFile =
                    await FilesService.UploadFileAsync(file: viewModel.ImageBanner, folder: "Banners");
                #endregion

                if (uploadFile is not null)
                {
                    // Insert Banner
                    var model = new Banner
                    {
                        Title = viewModel.Title,
                        Url = viewModel.Url,
                        File = uploadFile,
                    };

                    await UnitOfWork.Banners.InsertAsync(entity: model);

                    //Insert File 
                    uploadFile.Banner = model;
                    uploadFile.BannerId = model.Id;
                    await UnitOfWork.Files.InsertAsync(entity: uploadFile);

                    await UnitOfWork.SaveAsync();

                    return RedirectToAction(actionName: "Index", controllerName: "Banners");
                }
                else
                    return View(model: viewModel);
            }
            catch (Exception)
            {
                //Logger    
                throw;
            }
        }
        #endregion

        // GET: Admin/Banners/Edit
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var foundedBanner =
                    await UnitOfWork.Banners.GetBannerByIdAsync(id: id);

                if (foundedBanner is null)
				{
                    // Logger
                    return NotFound();
				}

                var viewModel = new ViewModels.AdminViewModels.Banners.EditViewModel
                {
                    Id = foundedBanner.Id,
                    Title = foundedBanner.Title,
                    ImageBannerName = foundedBanner.File?.Name,
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

        // POST: Admin/‌Banners/Edit
        #region Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedBanner =
                    await UnitOfWork.Banners.GetBannerByIdAsync(id: viewModel.Id);

				if (foundedBanner is null)
					return View(model: viewModel);

				if (viewModel.ImageBanner?.Length > 0)
                {
                    if(foundedBanner.File is null)
					{
                        #region Add File
                        Models.File uploadFile =
                            await FilesService.UploadFileAsync(file: viewModel.ImageBanner, folder: "Banners");
                        #endregion

                        if (uploadFile is not null)
                        {
                            //Insert File 
                            uploadFile.BannerId = foundedBanner.Id;
                            await UnitOfWork.Files.InsertAsync(entity: uploadFile);
                        }
                        else
                        {
                            // Log
                            return NotFound(value: "Problem is about Upload New File");
                        }
                    }
					else
					{
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedBanner.File);

                        if (isDeleteFile)
                        {
                            #region Add File
                            Models.File uploadFile =
                                await FilesService.UploadFileAsync(file: viewModel.ImageBanner, folder: "Banners");
                            #endregion

                            if (uploadFile is not null)
                            {
                                // Update File
                                foundedBanner.File.Name = uploadFile.Name;
                                foundedBanner.File.ContentType = uploadFile.ContentType;
                                foundedBanner.File.Path = uploadFile.Path;
                                foundedBanner.File.Size = uploadFile.Size;
                                foundedBanner.File.Alt = uploadFile.Alt;
                                UnitOfWork.Files.Update(entity: foundedBanner.File);
                            }
                            else
                            {
                                // Log
                                return NotFound(value: "Problem is about Upload New File");
                            }
                        }
                        else
                        {
                            // Log
                            return NotFound(value: "Problem is about Delete Old File");
                        }
                    }
                }

                //Update Banner
                foundedBanner.Title = viewModel.Title;
                foundedBanner.Url = viewModel.Url;
                UnitOfWork.Banners.Update(entity: foundedBanner);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Banners");
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Banners/Delete
        #region Delete
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                var foundedBanner =
                    await UnitOfWork.Banners.GetBannerByIdAsync(id: Guid.Parse(id));

                if (foundedBanner is not null)
                {
                    if (foundedBanner.File is not null)
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedBanner.File);

                        if (isDeleteFile)
                            UnitOfWork.Files.Delete(entity: foundedBanner.File);
                    }

                    UnitOfWork.Banners.Delete(entity: foundedBanner);

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
    }
}
