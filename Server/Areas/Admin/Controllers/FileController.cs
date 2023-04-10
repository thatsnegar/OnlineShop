using Microsoft.AspNetCore.Mvc;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class FileController : Infrastructure.BaseControllerWithDataBase
	{
        public FileController(DAL.IUnitOfwork unitOfWork, Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment, Services.IFilesService filesService) : base(unitOfWork)
        {
            HostEnvironment = hostEnvironment;

            FilesService = filesService;
        }

        protected Services.IFilesService FilesService { get; }
        protected Microsoft.Extensions.Hosting.IHostEnvironment HostEnvironment { get; }

        [HttpPost]
        [Route("file-upload")]
        public async Task<IActionResult> UploadFile(Microsoft.AspNetCore.Http.IFormFile upload)
        {
            if (upload.Length <= 0)
                return null;

            #region Add File
            Models.File uploadFile =
                await FilesService.UploadFileAsync(file: upload, folder: "UploasdFiles");
            #endregion

            string url =
                $"{"/emoniFiles/UploasdFiles/"}{uploadFile.Name}";

            return Json(new { uploaded = true, url });
        }

        [Route("file_Browser")]
        public IActionResult FileBrowser()
        {
            var dir =
                new System.IO.DirectoryInfo(System.IO.Path.Combine(HostEnvironment.ContentRootPath, "emoniFiles", "UploasdFiles"));

            ViewBag.File = dir.GetFiles();

            return View("FileBrowser");
        }

        [HttpPost]
        [Route("file_Browser")]
        public IActionResult Upload(Microsoft.AspNetCore.Http.IFormFile upload)
        {

            return View("FileBrowser");
        }
    }
}
