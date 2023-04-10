using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Sliders;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class SliderController : Infrastructure.BaseControllerWithDataBase
    {
        public SliderController(DAL.IUnitOfwork unitOfWork, Services.IFilesService filesService) : base(unitOfWork)
        {
            FilesService = filesService;
        }

        protected Services.IFilesService FilesService { get; }

        // **************************************************
        // **************************************************

        // GET: Admin/Slider
        #region Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var indexViewModel = new List<IndexViewModel>();

                var foundedSliders =
                   await UnitOfWork.Sliders.GetAllSlidersAsync();

                if (foundedSliders.Any())
                {
                    indexViewModel.AddRange(collection: foundedSliders.Select(item => new IndexViewModel
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
                // Logger
                throw;
            }
        }
        #endregion

        // GET: Admin/Slider/Create
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

        // POST: Admin/Slider/Create
        #region Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model: viewModel);
                }

                #region Add File
                Models.File uploadFile =
                    await FilesService.UploadFileAsync(file: viewModel.ImageSlider!, folder: "sliders");
                #endregion

                if (uploadFile is not null)
                {
                    // Insert Slider
                    var model = new Slider
                    {
                        Title = viewModel.Title,
                        Description = viewModel.Description,
                        File = uploadFile,
                    };
                    await UnitOfWork.Sliders.InsertAsync(entity: model);

                    // Insert File
                    uploadFile.Slider = model;
                    uploadFile.SliderId = model.Id;
                    await UnitOfWork.Files.InsertAsync(entity: uploadFile);

                    await UnitOfWork.SaveAsync();

                    return RedirectToAction(actionName: "Index", controllerName: "Slider");
                }
                else
                    return View(model: viewModel);

            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
        #endregion

        // GET: Admin/Slider/Edit
        #region Edit
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                var foundedSlider =
                    await UnitOfWork.Sliders.GetSliderByIdAsync(id: id);

                var viewModel = new ViewModels.AdminViewModels.Sliders.EditViewModel
                {
                    Id = foundedSlider.Id,
                    Title = foundedSlider.Title,
                    Description = foundedSlider.Description,
                    ImageSliderName = foundedSlider.File.Name,
                };

                if (foundedSlider != null)
                    return View(model: viewModel);

                else
                    return NotFound();
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Slider/Edit
        #region Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedSlider =
                    await UnitOfWork.Sliders.GetSliderByIdAsync(id: viewModel.Id);

                if (foundedSlider is null)
                    return View(model: viewModel);

                if (viewModel.ImageSlider?.Length > 0)
                {
                    if(foundedSlider.File is null)
					{
                        #region Add File
                        Models.File uploadFile =
                            await FilesService.UploadFileAsync(file: viewModel.ImageSlider!, folder: "sliders");
                        #endregion

                        if (uploadFile is not null)
                        {
                            // Insert File
                            uploadFile.Slider = foundedSlider;
                            uploadFile.SliderId = foundedSlider.Id;
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
                            FilesService.DeleteFile(file: foundedSlider.File);

                        if (isDeleteFile)
                        {
                            #region Add File
                            Models.File uploadFile =
                                await FilesService.UploadFileAsync(file: viewModel.ImageSlider!, folder: "sliders");
                            #endregion

                            if (uploadFile is not null)
                            {
                                // Update File
                                foundedSlider.File.Name = uploadFile.Name;
                                foundedSlider.File.ContentType = uploadFile.ContentType;
                                foundedSlider.File.Path = uploadFile.Path;
                                foundedSlider.File.Size = uploadFile.Size;
                                foundedSlider.File.Alt = uploadFile.Alt;
                                UnitOfWork.Files.Update(entity: foundedSlider.File);
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

                // Update Slider
                foundedSlider.Title = viewModel.Title;
                foundedSlider.Description = viewModel.Description;
                UnitOfWork.Sliders.Update(entity: foundedSlider);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Slider");
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Slider/Delete
        #region Delete
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                var foundedSlider =
                    await UnitOfWork.Sliders.GetSliderByIdAsync(id: Guid.Parse(id));

                if (foundedSlider is not null)
                {
                    if (foundedSlider.File is not null)
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedSlider.File);

                        if (isDeleteFile)
                            UnitOfWork.Files.Delete(entity: foundedSlider.File);
                    }

                    UnitOfWork.Sliders.Delete(entity: foundedSlider);

                    await UnitOfWork.SaveAsync();

                    result = true;

                    return Json(data: result);
                }
                else
                {
                    // Logger
                    return Json(data: result);
                }
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
        #endregion
    }
}
