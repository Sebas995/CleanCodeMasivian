using System;

namespace Models
{
    public class RouletteModel 
    {
        /// <summary>
        /// Id of bet
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Roulette open (true or false)
        /// </summary>
        public bool RouletteOpen { get; set; }
        /// <summary>
        /// Date open of roulette
        /// </summary>
        public DateTime? Open { get; set; }
        /// <summary>
        /// Date close of roulette
        /// </summary>
        public DateTime? Close { get; set; }
    }
}
