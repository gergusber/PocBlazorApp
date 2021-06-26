using CRUDPOC.Data.EfCore5.Configure;
using CRUDPOC.Domain.models;
using DotNetCore.EntityFrameworkCore;

namespace CRUDPOC.Data.EfCore5.Repository
{
    public class DeveloperTestRepository : EFRepository<Developer>, IDeveloperTestRepository

    {
        private readonly Context _context;

        public DeveloperTestRepository(Context context) : base(context)
        {
        }
    }
}