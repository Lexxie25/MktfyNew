﻿using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    public class UserRepository : BaseRepository<User, string, ApplicationDbContext>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

    }
}
