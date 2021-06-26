using CRUDPOC.Application.Developers;
using CRUDPOC.Domain.Interfaces;
using CRUDPOC.Domain.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Infraestructure.Services
{
    public class DeveloperService : IDevelopersApi//IDeveloperService
    {
        private readonly IDeveloperRepository _devRepo;

        public DeveloperService(IDeveloperRepository devRepo)
        {
            _devRepo = devRepo;
        }

        public async Task<Developer> Add(Developer obj) => await _devRepo.Add(obj);

        public async Task<IEnumerable<Developer>> GetAll() => await _devRepo.GetAll();

        public async Task<Developer> GetById(int id) => await _devRepo.GetById(id);

        public async Task Remove(int id) => await _devRepo.Remove(id);

        public async Task<Developer> Update(Developer obj) => await _devRepo.Update(obj);
    }
}