using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Roles;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class RoleController : Infrastructure.BaseControllerWithDataBase
    {
        public RoleController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }

        // GET: Admin/Role
        #region Index
        public async Task<IActionResult> Index()
        {
            try
            {
                var indexViewModels = new List<IndexViewModel>();

                var foundedRoles =
                    await UnitOfWork.Roles.GetAllRolesAsync();

                if (foundedRoles.Any())
                {
                    indexViewModels.AddRange(foundedRoles.Select(item => new IndexViewModel()
                    {
                        Id = item.Id,
                        IsEditted = item.IsEdited,
                        InsertDateTime = item.InsertDateTime,
                        UpdateDateTime = item.UpdateDateTime,
                        Name = item.Name,
                    }));

                    return View(model: indexViewModels);
                }
                else
                {
                    List<IndexViewModel> model = null;

                    model ??= new List<IndexViewModel>();

                    return View(model: model);
                }
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Role/Create
        #region Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(actionName: "Index", controllerName: "Role");

                var model = new Role
                {
                    Name = viewModel.Name,
                };

                await UnitOfWork.Roles.InsertAsync(entity: model);
                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Role");
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
        #endregion

        // Get: Admin/Role/Edit
        #region Edit
        [HttpGet]
        public async Task<JsonResult> Edit(string id)
        {
            try
            {
                string result = System.String.Empty;

                if (string.IsNullOrEmpty(value: id))
                    return Json(result);

                var foundedRoles =
                    await UnitOfWork.Roles.GetRoleByIdAsync(id: Guid.Parse(input: id));

                if (foundedRoles is not null)
                {
                    var viewModel = new EditViewModel()
                    {
                        Id = foundedRoles.Id,
                        Name = foundedRoles.Name,
                    };

                    result = System.Text.Json.JsonSerializer.Serialize(value: viewModel);

                    return Json(data: result);
                }
                else
                    return Json(data: result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // POST: Admin/Role/Edit
        #region Edit
        [HttpPost]
        public async Task<JsonResult> Edit(string id, string name)
        {
            try
            {
                bool result = false;
                if (!ModelState.IsValid)
                    return Json(data: result);

                var foundedRole =
                    await UnitOfWork.Roles.GetByIdAsync(id: Guid.Parse(input: id));

                if (foundedRole is not null)
                {
                    foundedRole.Name = name;

                    UnitOfWork.Roles.Update(entity: foundedRole);

                    await UnitOfWork.SaveAsync();

                    result = true;

                    return Json(data: result);
                }
                else
                {
                    return Json(data: result);
                }
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
        #endregion

        // POST: Admin/Role/Delete
        #region Delete
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var foundedRole = await UnitOfWork.Roles.GetByIdAsync(id: Guid.Parse(input: id));

                if (foundedRole is not null)
                {
                    UnitOfWork.Roles.Delete(entity: foundedRole);

                    await UnitOfWork.SaveAsync();

                    result = true;

                    return Json(data: result);
                }
                else
                {
                    return Json(data: result);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
