using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CleanCodeMasivian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private RoulleteBLL roulleteBLL;

        public RouletteController(RoulleteBLL roulleteBLL)
        {
            this.roulleteBLL = roulleteBLL;
        }

        /// <summary>
        /// Return all roulette
        /// </summary>
        /// <returns>Return all roulette</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouletteModel>>> GetRoulettes()
        {
            return await roulleteBLL.GetRoulettes();
        }

        /// <summary>
        /// Create Roulete
        /// </summary>
        /// <returns>Data of roulette created</returns>
        [HttpPost]
        public async Task<ActionResult<RouletteModel>> PostRouletteModel()
        {
            return await roulleteBLL.PostRouletteModel();
        }

        /// <summary>
        /// Open roulette
        /// </summary>
        /// <param name="id">Id of roulette</param>
        /// <returns>Success or false</returns>
        [HttpPost("{id}/OpenRoulette")]
        public async Task<ActionResult<string>> PutRouletteModel(Guid id)
        {
            return await roulleteBLL.PutRouletteModel(id);
        }

        /// <summary>
        /// Create bet for roulette
        /// </summary>
        /// <param name="id">Id of roulette</param>
        /// <param name="UserId">Id of user</param>
        /// <param name="betModel">Bet</param>
        /// <returns>Success or False</returns>
        [HttpPost("{id}/BetRoulette")]
        public async Task<ActionResult<string>> BetRouletteModel(Guid id, [FromHeader(Name="userId")] string userId, BetModel betModel)
        {
            return await roulleteBLL.BetRouletteModel(id, userId, betModel);
        }

        /// <summary>
        /// Close Roulete and return data of bets
        /// </summary>
        /// <param name="id">Id of Roulette</param>
        /// <returns>List of bets for Roulette</returns>
        [HttpDelete("{id}/CloseRoulete")]
        public async Task<ActionResult<List<BetModel>>> DeleteRouletteModel(Guid id)
        {
            return await roulleteBLL.DeleteRouletteModel(id);
        }
    }
}
