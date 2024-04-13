using apis.Models;

namespace apis.Utils
{
    public class UploadImage
    {
        private readonly IWebHostEnvironment _env;

        public UploadImage(IWebHostEnvironment env)
        {
            this._env = env;
        }



        string pathToNewFolder = System.IO.Path.Combine("Image", "Customer");
        public async Task<string>  Upload(IFormFile file)
        {

                var upload = Path.Combine(_env.ContentRootPath, pathToNewFolder);
                try
                {
                    DirectoryInfo directory = Directory.CreateDirectory(pathToNewFolder);
                    var filePath = Path.Combine(Path.GetRandomFileName() + file.FileName);

                    using (var stream = new FileStream(Path.Combine(upload, filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return filePath;
                }
                catch { throw new HttpException(500, "Upload File Error. Please try again."); }

        }
        public void Delete(string nameFile)
        {
              var upload = Path.Combine(_env.ContentRootPath, pathToNewFolder);
            if (!string.IsNullOrEmpty(nameFile))
            {


                if (System.IO.File.Exists(Path.Combine(upload, nameFile)))
                {
                    System.IO.File.Delete(Path.Combine(upload, nameFile));
                }

            }
        }
    }
}
