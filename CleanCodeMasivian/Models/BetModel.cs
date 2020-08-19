using System;
using System.ComponentModel.DataAnnotations;

namespace CleanCodeMasivian.Models
{
    public class BetModel
    {
        [Key]
        public Guid Id {get;set;}
        public Guid IdRoulette {get;set;}
        /// <summary>
        /// Position of bet (0, 36)
        /// </summary>
        public int BetPosition {get;set;}
        /// <summary>
        /// Color of bet (Red or Black)
        /// </summary>
        public string BetColor {get;set;}
        /// <summary>
        /// Money to bet
        /// </summary>
        public double BetMoney {get;set;}
    }
}
