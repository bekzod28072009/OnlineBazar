using Bazar.Service.DTOs.Attachments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.Extensions
{
    public static class FromFileExtension
    {
        public static AttachmentForCreateDto ToAttachmentOrDefault(this IFormFile formFile)
        {

            if (formFile?.Length > 0)
            {
                using var ms = new MemoryStream();
                formFile.CopyTo(ms);
                var fileBytes = ms.ToArray();

                return new AttachmentForCreateDto()
                {
                    Path = formFile.FileName,
                    Stream = new MemoryStream(fileBytes)
                };
            }

            return null;
        }
    }
}
