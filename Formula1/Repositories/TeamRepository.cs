using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formula1.Data;
using Formula1.Models;
using Microsoft.EntityFrameworkCore;
namespace Formula1.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeams();
    }

    public class TeamRepository : ITeamRepository
    {
        private IFormulaContext _context;
        public TeamRepository(IFormulaContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.Include(b => b.Drivers).ToListAsync();
        }

        // public async Task<List<Team>> DeleteTeam(int TeamId)
        // {
        //     Team Team = _context.Teams.First(t => t.TeamId == TeamId);
        //     _context.Teams.Remove(Team);
        //     return await _context.Teams.Where(m => m.TeamId == TeamId).Include(b => b.Drivers).ToListAsync();
        // }
    }
}
