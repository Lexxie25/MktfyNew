using MKTFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories
{
    public interface IUnitOfWork
    {
        //repositories 
        IListingRepository Listings { get; }
        IUserRepository Users { get; }
        IUploadRepository Uploads { get; }

        // save method
        Task SaveAsync();
    }
}
