using Itis_bet.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Itis_bet.Models
{
    [Table("Bets")]
    public class Bets
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id")]
        public Guid Id { get; set; }


        public Guid Match_Id { get; set; }

        [ForeignKey("Match_Id")]
        public Matches Match { get; set; }


        [Required]
        public string Description { get; set; }


        public double Coef { get; set; }


        [Required]
        [Column(TypeName = "varchar(255)")]
        public BetStatus Status { get; set; }
    }
}
