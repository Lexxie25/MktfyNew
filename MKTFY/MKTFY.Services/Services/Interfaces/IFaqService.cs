using MKTFY.Models.ViewModels.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services.Interfaces
{
    public interface IFaqService
    {
        Task<FaqVM> Create(FaqAddVM src);

        Task<FaqVM> GetById(Guid id);

        Task<List<FaqVM>> GetAll();

        Task<FaqVM> Update(FaqUpdateVM src);

        Task Delete(Guid id);
    }
}
