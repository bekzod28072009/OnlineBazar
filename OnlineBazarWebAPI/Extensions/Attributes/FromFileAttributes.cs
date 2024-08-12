using System.ComponentModel.DataAnnotations;

namespace OnlineBazarWebAPI.Extensions.Attributes
{
    public class FromFileAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                string[] extensions = new string[] { ".png", ".jpg" };
                var extension = Path.GetExtension(file.FileName);

                if (!extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult("This photo extension is not allowed!");
                }
                if (file.Length > 4048)
                {
                    return new ValidationResult("File should be less or equal to 2 mb");
                }
            }
            return ValidationResult.Success;
        }
    }
}
