using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Extensions
{
    public static class FileHelper
    {
        public static async Task<string> FileUploadDataAsync(IFormFile doc, string Field)
        {
            if (doc == null)
            {
                return string.Empty;
            }
            string regFileName = Path.GetFileNameWithoutExtension(doc.Name) + "_" + "Field_" + DateTime.Now.ToString("yyyy_mm_dd_hh_mm_ss") + Path.GetExtension(doc.FileName);
            long regSize = doc.Length;
            var regPath = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", Field);
            if (!Directory.Exists(regPath))
            {
                Directory.CreateDirectory(regPath);
            }
            var filePath = Path.Combine(regPath, regFileName);
            if (regSize > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await doc.CopyToAsync(stream);
                }
            }

            return $"/{Field}/{regFileName}";
        }
    }
}
