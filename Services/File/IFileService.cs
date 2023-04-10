namespace Services
{
    public interface IFilesService
    {
        // Add file 
        System.Threading.Tasks.Task<Models.File> UploadFileAsync(Microsoft.AspNetCore.Http.IFormFile file, string folder);

        // Add files
        System.Threading.Tasks.Task<List<Models.File>> UploadFilesAsync(List<Microsoft.AspNetCore.Http.IFormFile> files, string folder);

        // Delete file
        bool DeleteFile(Models.File file);

        // Delete files
        bool DeleteFiles(List<Models.File> files);
    }
}

    