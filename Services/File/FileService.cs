using System.Text;

namespace Services
{
    public class FileService : IFilesService
    {
        public FileService(Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment) : base()
        {
            HostEnvironment = hostEnvironment;

            PhysicalRootPath =
                $"{HostEnvironment.ContentRootPath}wwwroot";

            CompanyName = "emoniFiles";
        }

        public string CompanyName { get; }

        public string PhysicalRootPath { get; }

        public Microsoft.Extensions.Hosting.IHostEnvironment HostEnvironment { get; }

        // **************************************************
        // **************************************************

        public async Task<Models.File> UploadFileAsync(Microsoft.AspNetCore.Http.IFormFile file, string folder)
        {
            try
            {
                string physicalPathFolder =
                    System.IO.Path.Combine(path1: PhysicalRootPath, path2: CompanyName, path3: folder);

                if (!System.IO.Directory.Exists(path: physicalPathFolder))
                {
                    System.IO.Directory.CreateDirectory(path: physicalPathFolder);
                }

                var extensionFile =
                    System.IO.Path.GetExtension(path: file.FileName);

                var fileName =
                    System.IO.Path.GetFileNameWithoutExtension(path: file.FileName);

                var newFileName =
                    $"{fileName}-{System.DateTime.Now:yyyy-MM-dd-hh-mm-ss-ffff}{extensionFile}";

                string physicalPathFile =
                    System.IO.Path.Combine(path1: physicalPathFolder, path2: newFileName);

                if (!System.IO.File.Exists(path: physicalPathFile))
                {
                    using System.IO.FileStream stream =
                        new(path: physicalPathFile, mode: System.IO.FileMode.Create);

                    await file.CopyToAsync(target: stream);
                }

                Models.File model = new()
                {
                    Name = newFileName,
                    ContentType = file.ContentType,
                    Path = System.IO.Path.Combine(path1: CompanyName, path2: folder, path3: newFileName),
                    Size = file.Length,
                    Alt = System.IO.Path.GetFileNameWithoutExtension(path: file.FileName),
                };

                return model;
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }

        public async Task<List<Models.File>> UploadFilesAsync(List<Microsoft.AspNetCore.Http.IFormFile> files, string folder)
        {
            try
            {
                string physicalPathFolder =
                    System.IO.Path.Combine(path1: PhysicalRootPath, path2: CompanyName, path3: folder);

                if (!System.IO.Directory.Exists(path: physicalPathFolder))
                {
                    System.IO.Directory.CreateDirectory(path: physicalPathFolder);
                }

                var models = new List<Models.File>();

                foreach (var file in files)
                {
                    var extensionFile =
                        System.IO.Path.GetExtension(path: file.FileName);

                    var fileName =
                        System.IO.Path.GetFileNameWithoutExtension(path: file.FileName);

                    var newFileName =
                        $"{fileName}-{System.DateTime.Now:yyyy-MM-dd-hh-mm-ss-ffff}{extensionFile}";

                    string physicalPathFile =
                        System.IO.Path.Combine(path1: physicalPathFolder, path2: newFileName);

                    if (!System.IO.File.Exists(path: physicalPathFile))
                    {
                        using System.IO.FileStream stream =
                            new(path: physicalPathFile, mode: System.IO.FileMode.Create);

                        await file.CopyToAsync(stream);
                    }

                    models.Add(new Models.File
                    {
                        Name = newFileName,
                        ContentType = file.ContentType,
                        Path = System.IO.Path.Combine(path1: CompanyName, path2: folder, path3: newFileName),
                        Size = file.Length,
                        Alt = System.IO.Path.GetFileNameWithoutExtension(path: file.FileName),
                    });
                }

                return models;
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }

        public bool DeleteFile(Models.File file)
        {
            try
            {
                string physicalPathFolder =
                    System.IO.Path.Combine(path1: PhysicalRootPath, path2: file.Path!);

                if (System.IO.File.Exists(path: physicalPathFolder))
                {
                    System.IO.File.Delete(path: physicalPathFolder);

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }

        public bool DeleteFiles(List<Models.File> files)
        {
            try
            {
                if (files.Any())
                {
                    foreach (var file in files)
                    {
                        string physicalPathFolder =
                            System.IO.Path.Combine(path1: PhysicalRootPath, path2: file.Path!);

                        if (System.IO.File.Exists(path: physicalPathFolder))
                        {
                            System.IO.File.Delete(path: physicalPathFolder);
                        }
                    }

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }

        //public async Task<bool> AddFile(string physicalPathFolder, Microsoft.AspNetCore.Http.IFormFile file)
        //{
        //    var extensionFile =
        //        System.IO.Path.GetExtension(path: file.FileName);

        //    var fileName =
        //        System.IO.Path.GetFileNameWithoutExtension(path: file.FileName);

        //    // String Builder:
        //    var newFileName =
        //        $"{fileName}-{System.DateTime.Now:yyyy-MM-dd-hh-mm-ss-ffff}{extensionFile}";

        //    string physicalPathFile =
        //        System.IO.Path.Combine(path1: physicalPathFolder, path2: newFileName);

        //    if (!System.IO.File.Exists(path: physicalPathFile))
        //    {
        //        using System.IO.FileStream stream =
        //            new(path: physicalPathFile, mode: System.IO.FileMode.Create);

        //        await file.CopyToAsync(target: stream);

        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }
}
