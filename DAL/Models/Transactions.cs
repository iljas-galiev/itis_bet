using Itis_bet.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Itis_bet.DAL.Models
{
    public class Transactions
    {
        public Guid Id { get; set; }


        public Guid User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { get; set; }

        [Required]
        public TransactionType Type { get; set; } 

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public decimal Money { get; set; }

        public Guid? User_Bet_Id { get; set; }
        [ForeignKey("User_Bet_Id")]
        public UsersBets UserBet { get; set; }
    } 
}
