using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Idntity
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<FileMetadata> FileMetadata { get; set; }
        public ICollection<FileApproval> FileApprovals { get; set; }

    }
}
