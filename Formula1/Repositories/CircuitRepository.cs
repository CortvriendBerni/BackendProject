using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Data;
using Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Repositories
{
    public interface ICircuitRepository
    {
        Task<List<Circuit>> GetCircuits();
    }

    public class CircuitRepository : ICircuitRepository
    {
        private IFormulaContext _context;
        public CircuitRepository(IFormulaContext context)
        {
            _context = context;
        }

        public async Task<List<Circuit>> GetCircuits()
        {
            return await _context.Circuits.ToListAsync();
        }
    }
}
