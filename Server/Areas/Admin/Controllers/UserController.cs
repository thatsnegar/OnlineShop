        using Models;
using Shared;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Users;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class UsersController : Infrastructure.BaseControllerWithDataBase
    {
        public UsersController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
        {
            FilesService = filesService;
        }

        protected Services.IFilesService FilesService { get; }

        // **************************************************
        // **************************************************

        // GET: Admin/Users
        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var indexViewModels = new List<IndexViewModel>();

                var foundedUsers =
                    await UnitOfWork.Users.GetAllUsersAsync();

                if (foundedUsers.Any())
                {
                    indexViewModels.AddRange(collection: foundedUsers.Select(item => new IndexViewModel
                    {
                        Id = item.Id,
                        IsActive = item.IsActive,
                        IsEditted = item.IsEdited,
                        InsertDateTime = item.InsertDateTime,
                        UpdateDateTime = item.UpdateDateTime,
                        Gender = item.Gender,
                        FullName = item.GetFullName(),
                        Username = item.Username,
                    }));

                    return View(model: indexViewModels);
                }
                else
                {
                    // Logger
                    return View(model: indexViewModels);
                }
            }
            catch (Exception)
            {
                // Logger
                throw;
            }

        }
        #endregion

        // GET: Admin/Users/Create
        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var createViewModel = new CreateViewModel();

                var foundedRoles =
                    await UnitOfWork.Roles.GetAllAsync();

                ViewBag.Roles =
                    new SelectList(items: foundedRoles, dataValueField: "Id", dataTextField: "Name", selectedValue: null);

                return View(model: createViewModel);
            }
            catch (Exception)
            {
                // Logger
                throw;
            }

        }
        #endregion

        // POST: Admin/Users/Create
        #region Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var foundedRoles = 
                        await UnitOfWork.Roles.GetAllAsync();
                    ViewBag.Roles =
                        new SelectList(items: foundedRoles, dataValueField: "Id", dataTextField: "Name", selectedValue: null);

                    return View(model: viewModel);
                }


                if (viewModel.RoleId.Equals(System.Guid.Empty))
                    return View(model: viewModel);

                var foundedRole =
                    await UnitOfWork.Roles.GetByIdAsync(id: viewModel.RoleId);

                if (foundedRole is null)
                {
                    // Logger
                    return View(model: viewModel);
                }

                var model = new User
                {
                    IsActive = true,
                    Gender = viewModel.Gender,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Username = viewModel.Username,
                    EmailAddress = viewModel.EmailAddress,
                    PhoneNumber = viewModel.PhoneNumber,
                    Password =(viewModel.Password is not null) ? viewModel.Password.Encode() : null,
                    RoleId = foundedRole.Id,
                };

                await UnitOfWork.Users.InsertAsync(entity: model);

                #region Add File
                if (viewModel.File is not null)
                {
                    Models.File uploadFile =
                        await FilesService.UploadFileAsync(file: viewModel.File, folder: "Users");

                    if (uploadFile is not null)
                    {
                        //Insert File 
                        uploadFile.UserId = model.Id;
                        await UnitOfWork.Files.InsertAsync(entity: uploadFile);
                    }
                    else
                    {
                        // Logger
                        return View(model: viewModel);
                    }
                }
                #endregion
                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Users");
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
        #endregion

        // GET: Admin/Users/Edit
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return NotFound();

                var foundedUser =
                    await UnitOfWork.Users.GetUserByIdAsync(id: id);

                if (foundedUser is not null)
                {
                    var viewModel = new EditViewModel()
                    {
                        Id = id,
                        Gender = foundedUser.Gender,
                        FirstName = foundedUser.FirstName,
                        LastName = foundedUser.LastName,
                        Username = foundedUser.Username,
                        EmailAddress = foundedUser.EmailAddress,
                        PhoneNumber = foundedUser.PhoneNumber,
                        RoleId = foundedUser.RoleId,
                        UserAvatar = foundedUser?.File?.Name,
                    };

                    if (foundedUser?.Role is not null)
                    {
                        var foundedRoles =
                            await UnitOfWork.Roles.GetAllAsync();
                        ViewBag.Roles =
                            new SelectList(items: foundedRoles, dataValueField: "Id", dataTextField: "Name", selectedValue: foundedUser.Role.Name);
                    }

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
        #endregion

        // POST: Admin/Users/Edit
        #region Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedUser =
                    await UnitOfWork.Users.GetUserByIdAsync(id: viewModel.Id);

                if (foundedUser is null)
                    return View(model: viewModel);

                // File
                #region File
                if (viewModel.File?.Length > 0)
                {
                    if (foundedUser.File is null) // No Image in wwwroot
                    {
                        #region Add File
                        Models.File uploadFile =
                            await FilesService.UploadFileAsync(file: viewModel.File, folder: "Users");

                        if (uploadFile is not null)
                        {
                            //Insert File 
                            uploadFile.IsMainFile = true;
                            uploadFile.UserId = foundedUser.Id;
                            await UnitOfWork.Files.InsertAsync(entity: uploadFile);
                        }
                        else
                        {
                            // Logger
                            return NotFound(value: "Problem is about Upload New File");
                        }
                        #endregion
                    }
                    else // Has Image in wwwroot
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedUser.File);

                        if (isDeleteFile)
                        {
                            #region Add File
                            Models.File uploadFile =
                                await FilesService.UploadFileAsync(file: viewModel.File, folder: "Users");

                            if (uploadFile is not null)
                            {
                                // Update File
                                foundedUser.File.Name = uploadFile.Name;
                                foundedUser.File.ContentType = uploadFile.ContentType;
                                foundedUser.File.Path = uploadFile.Path;
                                foundedUser.File.Size = uploadFile.Size;
                                foundedUser.File.Alt = uploadFile.Alt;

                                UnitOfWork.Files.Update(entity: foundedUser.File);
                            }
                            else
                            {
                                // Log
                                return NotFound(value: "Problem is about Upload New File");
                            }
                            #endregion
                        }
                        else
                        {
                            // Logget
                            return NotFound(value: "Problem is about Delete Old File");
                        }
                    }
                }
                #endregion

                // Update User
                foundedUser.Gender = viewModel.Gender;
                foundedUser.FirstName = viewModel.FirstName;
                foundedUser.LastName = viewModel.LastName;
                foundedUser.Username = viewModel.Username;
                foundedUser.EmailAddress = viewModel.EmailAddress;
                foundedUser.PhoneNumber = viewModel.PhoneNumber;
                foundedUser.RoleId = viewModel.RoleId;
                UnitOfWork.Users.Update(entity: foundedUser);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Users");
            }
            catch (Exception)
            {
                // Log
                throw;
            }
        }
        #endregion

        // POST: Admin/Users/Delete
        #region Delete
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                var foundedUser =
                    await UnitOfWork.Users.GetUserByIdAsync(id: Guid.Parse(id));

                if (foundedUser is not null)
                {
                    if (foundedUser.File is not null)
                    {
                        var isDeleteFile =
                            FilesService.DeleteFile(file: foundedUser.File);

                        if (isDeleteFile)
                            UnitOfWork.Files.Delete(entity: foundedUser.File);
                    }

                    UnitOfWork.Users.Delete(entity: foundedUser);

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
                // Logger
                throw;
            }
        }
        #endregion
    }
}
