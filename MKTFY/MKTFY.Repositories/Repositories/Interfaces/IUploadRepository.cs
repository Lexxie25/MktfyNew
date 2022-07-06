using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    public interface IUploadRepository
    {
        void Create(Upload entity);  // creates new Image 

        Task<Upload> GetById(Guid id);  // gets a single Image by existing ID

        Task<List<Upload>> GetAll();  //Get all of the Images 

        void Update(Upload entity);  //Updates an existing image

        void Delete(Upload entity);  // deletes an Image 
    }
}
