using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Itis_bet.Models
{
    [Table(name: "Users")]
    public class Users:IdentityUser<Guid>
    {
        [Column(name: "Passport")]
        [DataType(DataType.ImageUrl)]
        public string Passport { get; set; }
        
        [Required]
        [DefaultValue(false)]
        [Column(name: "Verificated")]
        public bool Verificated { get; set; }

        [Column(name: "Avatar")]
        public string Avatar { get; set; }

        [Column(name: "Money")]
        public decimal Money { get; set; }
    }
}
