using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Upload;
using MKTFY.Repositories;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services
{
    public class UploadService : IUploadService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _uow;

        public UploadService(IConfiguration config, IUnitOfWork uow)
        {
            _config = config;
            _uow = uow;
        }

        public async Task<List<UploadResultVM>> UploadFiles(List<IFormFile> files)
        {
            var results = new List<UploadResultVM>();

            //Iterate over all the files 
            foreach (var file in files)
            {
                var newId = Guid.NewGuid();
                var bucket = _config.GetSection("AWS").GetValue<string>("ImageBucket");
                var region = _config.GetSection("AWS").GetValue<string>("Region");

                //Preform the Upload to S3
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    // Upload the files
                    var s3Client = new AmazonS3Client(Amazon.RegionEndpoint.GetBySystemName(region));
                    var fileTransfer = new TransferUtility(s3Client);
                    await fileTransfer.UploadAsync(memoryStream, bucket, newId.ToString());

                }
                _uow.Uploads.Create(new Upload
                {
                    Id = newId,
                    Url = $"https://{bucket}.s3.{region}.amazonaws.com/{newId}"
                });
                await _uow.SaveAsync();

                //build out responce object
                results.Add(new UploadResultVM
                {
                    Id = newId
                });
            }
            return results;
        }
    }
}
