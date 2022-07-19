using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    public class FaqRepository : BaseRepository<Faq, Guid, ApplicationDbContext>, IFaqRepository
    {
        public FaqRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
