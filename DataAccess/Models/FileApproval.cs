using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class FileApproval  : BaseModel
    {
        public int FileMetadataId { get; set; }
        public string EmployeeName { get; set; } 
        public int Order { get; set; } 
        public bool IsApproved { get; set; }
        public virtual FileMetadata FileMetadata { get; set; }
    }
}
