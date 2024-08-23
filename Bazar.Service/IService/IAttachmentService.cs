using Bazar.Domain.Entities.Commons;
using Bazar.Service.DTOs.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.IService
{
    public interface IAttachmentService
    {
        ValueTask<Attachment> UploadAsync(AttachmentForCreateDto dto);
        ValueTask<Attachment> UploadToCTFAsync(AttachmentForCreateDto dto, long Id);
        ValueTask<Attachment> UploadToGroupAsync(AttachmentForCreateDto dto, long Id);
        ValueTask<Attachment> UploadToUserAsync(AttachmentForCreateDto dto, long Id);
        ValueTask<Attachment> UpdateAsync(int id, Stream stream);
        ValueTask<Attachment> CreateAsync(string filePath);
    }
}
