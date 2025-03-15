using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application._Shared
{
    public class ImageUploader
    {
        private readonly string _uploadFolder;

        public ImageUploader(string uploadFolder)
        {
            _uploadFolder = uploadFolder;

            // اگر پوشه‌ای برای ذخیره تصاویر وجود ندارد، آن را ایجاد می‌کنیم
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("فایل تصویری معتبر نیست.");
            }

            // ایجاد یک نام یکتا برای فایل
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(_uploadFolder, fileName);

            // ذخیره تصویر در پوشه مشخص شده
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // بازگرداندن مسیر فایل ذخیره شده
            return filePath;
        }
    }
}
