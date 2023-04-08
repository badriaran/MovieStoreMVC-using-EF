﻿using MovieStoreMVC.Repositories.Abstract;

namespace MovieStoreMVC.Repositories.Implementation
{
    public class FileService:IFileService
    {
        private readonly IWebHostEnvironment environment;
        public FileService(IWebHostEnvironment Env)
        {
            this.environment = Env; 
            
        }


        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var wwwPath = this.environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //check the allowed extensions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtension = new string[] { ".jpg", ".png", ".jpge" };
                if(!allowedExtension.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",",allowedExtension) );
                        return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }

        }
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath= this.environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads", imageFileName);
                if(System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
                
            } 
        }
    }
}
