using CRUDPOC.Data.EfCore.Configure;
using CRUDPOC.Domain.Interfaces;
using CRUDPOC.Domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Data.EfCore.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDBContext _context;

        public DeveloperRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //public async Task Add(Developer obj)
        //{
        //    try
        //    {
        //        await _context.Developers.AddAsync(obj);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<Developer> Add(Developer obj)
        {
            try
            {
                await _context.Developers.AddAsync(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            try
            {
                return await _context.Developers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Developer> GetById(string id)
        {
            return new Developer();
        }

        public async Task<Developer> GetById(int id)
        {
            try
            {
                return await _context.Developers.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var dev = await _context.Developers.FirstOrDefaultAsync(a => a.Id == id);
                _context.Remove(dev);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task Update(Developer obj)
        //{
        //    try
        //    {
        //        _context.Entry(obj).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public async Task<Developer> Update(Developer obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                var something = await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}