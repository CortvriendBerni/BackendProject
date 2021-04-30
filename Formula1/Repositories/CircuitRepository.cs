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
        Task<List<Circuit>> DeleteCircuit(string CircuitId);
        Task<List<Circuit>> GetCircuits();
        Task<List<Circuit>> PostCircuit(Circuit circuit);
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

        public async Task<List<Circuit>> PostCircuit(Circuit circuit)
        {
            var addCircuit = _context.Circuits.Add(circuit);
            return await _context.Circuits.Where(m => m.CircuitId == circuit.CircuitId).ToListAsync();
        }

        public async Task<List<Circuit>> DeleteCircuit(string CircuitId)
        {
            Circuit Circuit = _context.Circuits.First(t => t.CircuitId == CircuitId);
            _context.Circuits.Remove(Circuit);
            return await _context.Circuits.Where(m => m.CircuitId == CircuitId).ToListAsync();
        }
    }
}
