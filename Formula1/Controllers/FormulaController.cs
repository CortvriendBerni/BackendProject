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

      /// <summary>
      /// Het ophalen van alle drivers
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/drivers")]
        public async Task<List<Driver>> GetDrivers(){
           return await _formulaService.GetDrivers();
        }
      /// <summary>
      /// Het weergeven van een specifieke driver
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/driver/{id}")]
        public async Task<Driver> GetDriver(int id){
           return await _formulaService.GetDriver(id);
        }

      /// <summary>
      /// Het ophalen van alle circuits
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/circuits")]
        public async Task<List<Circuit>> GetCircuits(){
           return await _formulaService.GetCircuits();
        }

      /// <summary>
      /// Het ophalen van een specifiek circuit
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/circuit/{id}")]
        public async Task<Circuit> GetCircuit(string id){
           return await _formulaService.GetCircuit(id);
        }

      /// <summary>
      /// Een circuit verwijderen
      /// </summary>
      /// <returns></returns>
        [HttpDelete]
        [Route("/circuit/{CircuitId}")]
        public async Task<Circuit> DeleteCircuit(string CircuitId){
           return await _formulaService.DeleteCircuit(CircuitId);
        }

      /// <summary>
      /// Een circuit toevoegen
      /// </summary>
      /// <returns></returns>
        [HttpPost]
        [Route("/circuit")]
        public async Task<Circuit> PostCircuit(Circuit circuit){
           return await _formulaService.PostCircuit(circuit);
        }

      /// <summary>
      /// Het ophalen van de ranking
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/ranking")]
        public async Task<List<Ranking>> GetRankings(){
           return await _formulaService.GetRankings();
        }
      
      /// <summary>
      /// Het ophalen van de teams
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/teams")]
        public async Task<List<Team>> GetTeams(){
           return await _formulaService.GetTeams();
        }

      /// <summary>
      /// Het ophalen van een specifiek team
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("/team/{id}")]
        public async Task<Team> GetTeam(int id){
           return await _formulaService.GetTeam(id);
        }
    }
}
