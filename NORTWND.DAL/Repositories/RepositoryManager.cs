using NORTWND.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.DAL.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly NORTHWNDContext _context;

        public RepositoryManager(NORTHWNDContext context)
        {
            _context = context;
        }

        private ICustomerRepository _customers;
        public ICustomerRepository Customers => _customers ??= new CustomerRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();

        }
    }
}
