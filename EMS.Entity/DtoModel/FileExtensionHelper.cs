using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EMS.Entity.DtoModel
{
    public class FileExtensionHelper : ValidationAttribute
    {
        /// <summary>
        /// Maximum File Size in MB
        /// </summary>
        public double _maxSize { get; set; }
        public string[] _acceptedFormat { get; set; }
        /// <summary>
        /// Max File size in MB
        /// </summary>
        /// <param name="MaxSize"></param>
        public FileExtensionHelper(double MaxSize, string acceptedFormat = "pdf")
        {
            _maxSize = MaxSize;
            _acceptedFormat = acceptedFormat?.Split(',');
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
         

            var file = value as IFormFile;
            if (file == null || file.Length == 0)
            {
                return ValidationResult.Success;
            }
            var fileExtension = System.IO.Path.GetExtension(file.FileName)?.Substring(1);
          
            if(!_acceptedFormat.Contains(fileExtension))
            {
                return new ValidationResult(GetErrorMessage(true));
            }
           
            if (file.Length > 2 * 1024 * 1024 )
            {
                return new ValidationResult(GetErrorMessage(false));
            }


            return ValidationResult.Success;

        }
        public double MaxSize => _maxSize;

        public string GetErrorMessage(bool FileExtensionError)
        {
            if (FileExtensionError)
                return $"The file uploaded has not correct format. Please upload only {_acceptedFormat.ToString()} format.";
            else
                return $"file size is greater than {_maxSize}.";
        }
        bool IsPdf(string path)
        {
            var pdfString = "%PDF-";
            var pdfBytes = Encoding.ASCII.GetBytes(pdfString);
            var len = pdfBytes.Length;
            var buf = new byte[len];
            var remaining = len;
            var pos = 0;
            using (var f = File.OpenRead(path))
            {
                while (remaining > 0)
                {
                    var amtRead = f.Read(buf, pos, remaining);
                    if (amtRead == 0) return false;
                    remaining -= amtRead;
                    pos += amtRead;
                }
            }
            return pdfBytes.SequenceEqual(buf);
        }
    }
}
