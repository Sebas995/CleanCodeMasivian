using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CleanCodeMasivian.Models;

namespace CleanCodeMasivian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly RouletteContext _context;

        public RouletteController(RouletteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return all roulette
        /// </summary>
        /// <returns>Return all roulette</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouletteModel>>> GetRoulettes()
        {
            return await _context.Roulettes.ToListAsync();
        }

        /// <summary>
        /// Create Roulete
        /// </summary>
        /// <returns>Data of roulette created</returns>
        [HttpPost]
        public async Task<ActionResult<RouletteModel>> PostRouletteModel()
        {
            RouletteModel rouletteModel = new RouletteModel
            {
                Id = Guid.NewGuid(),
                RouletteOpen = false,
                Open = null,
                Close = null
            };
            _context.Roulettes.Add(rouletteModel);
            await _context.SaveChangesAsync();
            return rouletteModel;
        }

        /// <summary>
        /// Open roulette
        /// </summary>
        /// <param name="id">Id of roulette</param>
        /// <returns>Success or false</returns>
        [HttpPost("{id}/OpenRoulette")]
        public async Task<ActionResult<string>> PutRouletteModel(Guid id)
        {
            string Response = String.Empty;
            var Roulette = await _context.Roulettes.FindAsync(id); 
            try
            {
                Roulette.RouletteOpen = true;
                Roulette.Open = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                Response = "Roulette open successfully.";
            }
            catch (Exception)
            {
                Response = "Error to open Roulette.";
            }
            return Response;
        }

        /// <summary>
        /// Create bet for roulette
        /// </summary>
        /// <param name="id">Id of roulette</param>
        /// <param name="UserId">Id of user</param>
        /// <param name="betModel">Bet</param>
        /// <returns>Success or False</returns>
        [HttpPost("{id}/BetRoulette")]
        public async Task<ActionResult<string>> BetRouletteModel(Guid id, [FromHeader(Name="userId")] string UserId, BetModel betModel)
        {
            string Response = String.Empty;
            var Roulette = await _context.Roulettes.FindAsync(id);
            try
            {
                if(Roulette.RouletteOpen==false) throw new Exception("Bet is not open.");
                if (betModel.BetPosition<=0 || betModel.BetPosition >= 36)
                    throw new Exception("Bet position is invalid.");
                else
                    if(betModel.BetColor.ToUpper() != "BLACK" && betModel.BetColor.ToUpper() != "RED" ) throw new Exception("Bet color is invalid.");

                if (betModel.BetMoney <= 0 || betModel.BetMoney >= 10000) throw new Exception("Count of money is invalid.");
                if (String.IsNullOrEmpty(UserId)) throw new Exception("User is invalid.");
                betModel.Id=Guid.NewGuid(); 
                betModel.IdRoulette=Roulette.Id; 
                _context.RoulettesBets.Add(betModel);
                await _context.SaveChangesAsync();
                Response = "Bet created successfully.";
            }
            catch (Exception e)
            {
                Response = e.Message;
            }
            return Response;
        }

        /// <summary>
        /// Close Roulete and return data of bets
        /// </summary>
        /// <param name="id">Id of Roulette</param>
        /// <returns>List of bets for Roulette</returns>
        [HttpDelete("{id}/CloseRoulete")]
        public async Task<ActionResult<List<BetModel>>> DeleteRouletteModel(Guid id)
        {
            var rouletteModel = await _context.Roulettes.FindAsync(id);
            if (rouletteModel == null)
                return NotFound();

            rouletteModel.RouletteOpen=false;
            rouletteModel.Close=DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return _context.RoulettesBets.Where(b => b.IdRoulette == id).ToList();
        }
    }
}
