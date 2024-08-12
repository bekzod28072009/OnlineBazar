using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs.Attachments
{
    public class AttachmentForCreateDto
    {
        public string Path { get; set; }
        public Stream Stream { get; set; }
    }
}
