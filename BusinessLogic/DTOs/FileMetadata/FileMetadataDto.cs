using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs.FileApproval;

namespace BusinessLogic.DTOs.FileMetadata
{
    public class FileMetadataDto
    {
        public int Id { get; set; }
        public string FileNumber { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; } // نص الحالة
        public string ResponsibleEmployee { get; set; }
        public List<FileApprovalDto> Approvals { get; set; }
    }
}
