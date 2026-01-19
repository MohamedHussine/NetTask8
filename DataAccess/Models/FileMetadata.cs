using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Enums;

namespace DataAccess.Models
{
    public class FileMetadata : BaseModel
    {
        public string FileNumber { get; set; } // رقم الملف
        public string Subject { get; set; } // الموضوع
        public int SubmitterId { get; set; } // مقدم الملف (Lookup)
        public FileStatus Status { get; set; } // حالة الملف (Enum)
        public int CategoryId { get; set; } // تصنيف الملف (Lookup)
        public string ResponsibleEmployee { get; set; } 
        public string AttachmentPath { get; set; } 

        // علاقة: الملف الواحد له عدة موافقات
        public virtual ICollection<FileApproval> Approvals { get; set; }

    }
}
