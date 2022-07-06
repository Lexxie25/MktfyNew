using MKTFY.Repositories.Repositories;
using MKTFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private IListingRepository _listingRepository;

        public IListingRepository Listings
        {
            get
            {
                if (_listingRepository == null)
                    _listingRepository = new ListingRepository(_context);

                return _listingRepository;
            }
        }

        private IUserRepository _userRepository;

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        private IUploadRepository _uploadRepository;

        public IUploadRepository Uploads
        {
            get
            {
                if (_uploadRepository == null)
                    _uploadRepository = new UploadRepository(_context);

                return _uploadRepository;
            }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UnitOfWork(ApplicationDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
