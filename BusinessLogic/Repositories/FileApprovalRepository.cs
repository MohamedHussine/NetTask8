using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Models;

namespace BusinessLogic.Repositories
{
    public class FileApprovalRepository : GeneralRepository<FileApproval>,IFileApprovalRepository
    {
        //for special logic
        public FileApprovalRepository(Context context) : base(context) { }

    }
}
