using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    public class ListingRepository : BaseRepository<Listing, Guid, ApplicationDbContext>, IListingRepository
    {

        public ListingRepository(ApplicationDbContext context)
            : base(context)
        {
        }

    }
}
