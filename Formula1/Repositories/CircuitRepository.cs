using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formula1.Data;
using Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Repositories
{
    public interface ICircuitRepository
    {
        Task<Circuit> DeleteCircuit(string circuitId);
        Task<Circuit> GetCircuit(string circuitId);
        Task<List<Circuit>> GetCircuits();
        Task<Circuit> PostCircuit(Circuit circuit);
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

        public async Task<Circuit> GetCircuit(string circuitId)
        {
            return await _context.Circuits.Where(m => m.CircuitId == circuitId).FirstOrDefaultAsync();
        }

        public async Task<Circuit> PostCircuit(Circuit circuit)
        {
            await _context.Circuits.AddAsync(circuit);
            await _context.SaveChangesAsync();
            return circuit;
        }

        public async Task<Circuit> DeleteCircuit(string circuitId)
        {
            Circuit Circuit = await _context.Circuits.Where(m => m.CircuitId == circuitId).FirstOrDefaultAsync();
            _context.Circuits.Remove(Circuit);
            await _context.SaveChangesAsync();
            return Circuit;
        }
    }
}
