using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.FAQ;
using MKTFY.Repositories;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services
{
    public class FaqService : IFaqService
    {
        private readonly IUnitOfWork _uow;
        public FaqService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        //Create a new faq
        public async Task<FaqVM> Create(FaqAddVM src)
        {
            var newEntity = new Faq(src);

            _uow.Faq.Create(newEntity);
            await _uow.SaveAsync();

            var model = new FaqVM(newEntity);

            return model;

        }

        // get all Faq
        public async Task<List<FaqVM>> GetAll()
        {
            var results = await _uow.Faq.GetAll();

            var models = results.Select(Faq => new FaqVM(Faq)).ToList();
            return models;

        }
        public async Task<FaqVM> GetById(Guid id)
        {

            var result = await _uow.Faq.GetById(id);

            var model = new FaqVM(result);


            return model;

        }
        //Update the Faq
        public async Task<FaqVM> Update(FaqUpdateVM src)
        {
            var entity = await _uow.Faq.GetById(src.Id);
            entity.Title = src.Title;
            entity.Description = src.Description;

            _uow.Faq.Update(entity);
            await _uow.SaveAsync();

            var model = new FaqVM(entity);

            return model;
        }

        //delete the Faq
        public async Task Delete(Guid id)
        {
            var entity = await _uow.Faq.GetById(id);

            _uow.Faq.Delete(entity);
            await _uow.SaveAsync();
        }
    }
}
