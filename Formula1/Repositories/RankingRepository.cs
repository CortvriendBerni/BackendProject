using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Data;
using Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Repositories
{
    public interface IRankingRepository
    {
        Task<List<Ranking>> GetRankings();
    }

    public class RankingRepository : IRankingRepository
    {
        private IFormulaContext _context;
        public RankingRepository(IFormulaContext context)
        {
            _context = context;
        }

        public async Task<List<Ranking>> GetRankings()
        {
            return await _context.Ranking.Include(b => b.Driver).ToListAsync();
        }
    }
}
