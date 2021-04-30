using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Models;
using Formula1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.Controllers
{
    [Authorize]
    [ApiController] 
    public class FormulaController : ControllerBase
    {
        private IFormulaService _formulaService;

        public FormulaController(IFormulaService formulaService)
        {
            _formulaService = formulaService;
        }

        [HttpGet]
        [Route("/drivers")]
        public async Task<List<Driver>> GetDrivers(){
           return await _formulaService.GetDrivers();
        }

        [HttpGet]
        [Route("/driver/{id}")]
        public async Task<List<Driver>> GetDriver(int id){
           return await _formulaService.GetDriver(id);
        }

        [HttpGet]
        [Route("/circuits")]
        public async Task<List<Circuit>> GetCircuits(){
           return await _formulaService.GetCircuits();
        }

        [HttpDelete]
        [Route("/circuits/{CircuitId}")]
        public async Task<List<Circuit>> DeleteCircuit(string CircuitId){
           return await _formulaService.DeleteCircuit(CircuitId);
        }

        [HttpPost]
        [Route("/circuit")]
        public async Task<List<Circuit>> PostCircuit(Circuit circuit){
           return await _formulaService.PostCircuit(circuit);
        }

        [HttpGet]
        [Route("/ranking")]
        public async Task<List<Ranking>> GetRankings(){
           return await _formulaService.GetRankings();
        }

        [HttpGet]
        [Route("/teams")]
        public async Task<List<Team>> GetTeams(){
           return await _formulaService.GetTeams();
        }

      //   [HttpDelete]
      //   [Route("/teams/{TeamId}")]
      //   public async Task<List<Team>> DeleteTeam(int TeamId){
      //      return await _formulaService.DeleteTeam(TeamId);
      //   }
    }
}
