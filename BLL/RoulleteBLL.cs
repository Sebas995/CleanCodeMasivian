using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class RoulleteBLL
    {
        private RoulleteDAL roulleteDAL;

        public RoulleteBLL(RoulleteDAL roulleteDAL)
        {
            this.roulleteDAL = roulleteDAL;
        }

        /// <summary>
        /// Return all roulette
        /// </summary>
        /// <returns>Return all roulette</returns>
        public async Task<List<RouletteModel>> GetRoulettes()
        {
            return await roulleteDAL.GetRoulettes();
        }

        /// <summary>
        /// Create Roulete
        /// </summary>
        /// <returns>Data of roulette created</returns>
        public async Task<RouletteModel> PostRouletteModel()
        {
            return await roulleteDAL.PostRouletteModel();
        }

        /// <summary>
        /// Open roulette
        /// </summary>
        /// <param name="id">Id of roulette</param>
        /// <returns>Success or false</returns>
        public async Task<string> PutRouletteModel(Guid id)
        {
            if(await roulleteDAL.PutRouletteModel(id))
            {
                return "Roulette open successfully.";
            }
            else
            {
                return "Error to open Roulette."; 
            }
        }

        /// <summary>
        /// Create bet for roulette
        /// </summary>
        /// <param name="id">Id of roulette</param>
        /// <param name="UserId">Id of user</param>
        /// <param name="betModel">Bet</param>
        /// <returns>Success or False</returns>
        public async Task<string> BetRouletteModel(Guid id, string userId, BetModel betModel)
        {
            if (await roulleteDAL.BetRouletteModel(id, userId, betModel))
            {
                return "Bet created successfully.";
            }
            else
            {
                return "Bet not created.";
            }
        }

        /// <summary>
        /// Close Roulete and return data of bets
        /// </summary>
        /// <param name="id">Id of Roulette</param>
        /// <returns>List of bets for Roulette</returns>
        public async Task<List<BetModel>> DeleteRouletteModel(Guid id)
        {
            return await roulleteDAL.DeleteRouletteModel(id);
        }
    }
}
