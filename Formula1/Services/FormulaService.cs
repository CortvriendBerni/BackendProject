using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Models;
using Formula1.Repositories;

namespace Formula1.Services
{
    public interface IFormulaService
    {
        Task<List<Circuit>> GetCircuits();
        Task<List<Driver>> GetDrivers();
        Task<List<Ranking>> GetRankings();
        Task<List<Team>> GetTeams();
    }

    public class FormulaService : IFormulaService
    {
        IDriverRepository _driverRepository;
        ICircuitRepository _circuitRepository;
        IRankingRepository _rankingRepository;
        ITeamRepository _teamRepository;

        public FormulaService(IDriverRepository driverRepository, ICircuitRepository circuitRepository, IRankingRepository rankingRepository, ITeamRepository teamRepository)
        {
            _driverRepository = driverRepository;
            _circuitRepository = circuitRepository;
            _rankingRepository = rankingRepository;
            _teamRepository = teamRepository;
        }

        public async Task<List<Driver>> GetDrivers()
        {
            return await _driverRepository.GetDrivers();
        }

        public async Task<List<Circuit>> GetCircuits()
        {
            return await _circuitRepository.GetCircuits();
        }

        public async Task<List<Ranking>> GetRankings()
        {
            return await _rankingRepository.GetRankings();
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _teamRepository.GetTeams();
        }

    }
}
