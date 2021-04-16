using Itis_bet.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Itis_bet.Models
{
    public class UsersBets
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid User_Id { get; set; }
        
        [ForeignKey("User_Id")]
        public Users User { get; set; }

        public Guid Bet_Id { get; set; }
        [ForeignKey("Bet_Id")]
        public Bets Bet { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        public decimal Money { get; set; }

        public double Coef { get; set; }

        [Required]
        public UserBetResult Result { get; set; }

        [Required]
        public UserBetPaymentStatus Status { get; set; }
    }
}
