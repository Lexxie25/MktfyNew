using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    internal class UploadRepository : BaseRepository<Upload, Guid, ApplicationDbContext>, IUploadRepository
    {

        public UploadRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
