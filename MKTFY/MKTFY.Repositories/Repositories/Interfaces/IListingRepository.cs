﻿using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    public interface IListingRepository : IBaseRepository<Listing, Guid>
    {

        //void Purchase(Listing entity);//taken out for now did not do a migration yet throwing errors 

    }
}
