using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels.AdminViewModels.Abouts;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class AboutsController : Infrastructure.BaseControllerWithDataBase
    {

        public AboutsController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
        {
            FilesService = filesService;
        }

        protected Services.IFilesService FilesService { get; }

        // **************************************************
        // **************************************************

        // GET: Admin/Abouts
        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var foundedAbouts = await UnitOfWork.Abouts.GetAllAboutsAsync();

                return View(model: foundedAbouts);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // GET: Admin/Consultation/Create
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

        // POST: Admin/Abouts/Create
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
                if (viewModel.AboutImage is null)
                    return View(model: viewModel);

                Models.File uploadFile =
                    await FilesService.UploadFileAsync(file: viewModel.AboutImage, folder: "Abouts");
                #endregion

                if (uploadFile is not null)
                {
                    // Insert About
                    var model = new About
                    {
                        Title = viewModel.Title,
                        File = uploadFile,
                        GoalDescription = viewModel.GoalDescription,
                        GoalTitle = viewModel.GoalTitle,
                        MissionDescription = viewModel.MissionDescription,
                        MissionTitle = viewModel.MissionTitle,
                        VisionDescription = viewModel.MissionTitle,
                        VisionTitle = viewModel.VisionTitle,
                        Slogan = viewModel.Slogan,
                        SubTitle = viewModel.SubTitle,
                        Text = viewModel.Text,
                    };

                    await UnitOfWork.Abouts.InsertAsync(entity: model);

                    //Insert File 
                    uploadFile.About = model;
                    uploadFile.AboutId = model.Id;
                    await UnitOfWork.Files.InsertAsync(entity: uploadFile);

                    await UnitOfWork.SaveAsync();

                    return RedirectToAction(actionName: "Index", controllerName: "Abouts");
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

        // GET: Admin/Abouts/Edit
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var foundedAbouts =
                    await UnitOfWork.Abouts.GetAboutByIdAsync(id: id);

                if (foundedAbouts is null)
                {
                    // Logger
                    return NotFound();
                }

                var viewModel = new ViewModels.AdminViewModels.Abouts.EditViewModel
                {
                    Id = foundedAbouts.Id,
                    Title = foundedAbouts.Title,
                    AboutImageName = foundedAbouts.File?.Name,
                    GoalDescription = foundedAbouts.GoalDescription,
                    GoalTitle = foundedAbouts.GoalTitle,
                    MissionDescription = foundedAbouts.MissionDescription,
                    MissionTitle = foundedAbouts.MissionTitle,
                    Slogan = foundedAbouts.Slogan,
                    SubTitle = foundedAbouts.SubTitle,
                    Text = foundedAbouts.Text,
                    VisionDescription = foundedAbouts.VisionDescription,
                    VisionTitle = foundedAbouts.VisionTitle,
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

        // POST: Admin/Abouts/Edit
        #region Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedAbout =
                    await UnitOfWork.Abouts.GetAboutByIdAsync(id: viewModel.Id);

                if (foundedAbout is null)
                    return View(model: viewModel);

                if (viewModel.AboutImage?.Length > 0)
                {
                    if (foundedAbout.File is null)
                    {
                        #region Edit File
                        Models.File uploadFile =
                            await FilesService.UploadFileAsync(file: viewModel.AboutImage, folder: "Abouts");
                        #endregion

                        if (uploadFile is not null)
                        {
                            //Insert File 
                            uploadFile.AboutId = foundedAbout.Id;
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
                            FilesService.DeleteFile(file: foundedAbout.File);

                        if (isDeleteFile)
                        {
                            #region Add File
                            Models.File uploadFile =
                                await FilesService.UploadFileAsync(file: viewModel.AboutImage, folder: "Abouts");
                            #endregion

                            if (uploadFile is not null)
                            {
                                // Update File
                                foundedAbout.File.Name = uploadFile.Name;
                                foundedAbout.File.ContentType = uploadFile.ContentType;
                                foundedAbout.File.Path = uploadFile.Path;
                                foundedAbout.File.Size = uploadFile.Size;
                                foundedAbout.File.Alt = uploadFile.Alt;
                                UnitOfWork.Files.Update(entity: foundedAbout.File);
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

                //Update About
                foundedAbout.Title = viewModel.Title;
                foundedAbout.Text = viewModel.Text;
                foundedAbout.Slogan = viewModel.Slogan;
                foundedAbout.SubTitle = viewModel.SubTitle;
                foundedAbout.GoalDescription = viewModel.GoalDescription;
                foundedAbout.GoalTitle = viewModel.GoalTitle;
                foundedAbout.VisionDescription = viewModel.VisionDescription;
                foundedAbout.VisionTitle = viewModel.VisionTitle;
                foundedAbout.MissionDescription = viewModel.MissionDescription;
                foundedAbout.MissionTitle = viewModel.MissionTitle;

                UnitOfWork.Abouts.Update(entity: foundedAbout);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Abouts");
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

                var foundedAbout =
                    await UnitOfWork.Abouts.GetAboutByIdAsync(id: Guid.Parse(id));

                if (foundedAbout is not null)
                {
                    if (foundedAbout.File is not null)
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedAbout.File);

                        if (isDeleteFile)
                            UnitOfWork.Files.Delete(entity: foundedAbout.File);
                    }

                    UnitOfWork.Abouts.Delete(entity: foundedAbout);

                    await UnitOfWork.SaveAsync();

                //var foundedAbouts = await UnitOfWork.Abouts.GetAllAboutsAsync();

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
        #region Confirm Being Active
        [HttpPost]
        public async Task<JsonResult> ConfirmBeingActive(string id)
        {
            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var foundedAbouts =
                    await UnitOfWork.Abouts.GetAllAsync();

                Models.About foundedAbout =
                    foundedAbouts.Where(current => current.Id.Equals(Guid.Parse(input: id))).FirstOrDefault();

                #region Deactivating
                foreach (var item in foundedAbouts.Where(current => current.IsActive).ToList())
                {
                    item.IsActive = false;

                    UnitOfWork.Abouts.Update(entity: item);
                }
                #endregion

                if (foundedAbout is not null)
                {
                    if (foundedAbout.IsActive == false)
                        foundedAbout.IsActive = true;
                    else
                        foundedAbout.IsActive = false;

                    UnitOfWork.Abouts.Update(entity: foundedAbout);

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
