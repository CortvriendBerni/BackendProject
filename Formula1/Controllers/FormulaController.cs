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
        [Route("/circuits")]
        public async Task<List<Circuit>> GetCircuits(){
           return await _formulaService.GetCircuits();
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
    }
}
