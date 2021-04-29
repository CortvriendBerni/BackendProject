using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Data;
using Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Repositories
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetDrivers();
    }

    public class DriverRepository : IDriverRepository
    {
        private IFormulaContext _context;
        public DriverRepository(IFormulaContext context)
        {
            _context = context;
        }

        public async Task<List<Driver>> GetDrivers()
        {
            return await _context.Drivers.Include(m => m.FavoriteCircuits).ThenInclude(am => am.Circuit).ToListAsync();
        }
    }
}
