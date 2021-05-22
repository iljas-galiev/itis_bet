using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Itis_bet.DAL.Models
{
    [Table(name: "Users")]
    public class Users:IdentityUser<Guid>
    {
        string email;
        bool verificated;
        string passport;
        bool canBetting;
        string avatar;
        decimal money;

        [Column(name: "Email")]
        public string Email { get; set; }

        [Column(name: "Verificated")]
        public bool Verificated { get { return verificated; } set { verificated = value; } }

        [Column(name: "Passport")]
        public string Passport { get { return passport; } set { passport = value; } }

        [Column(name: "CanBetting")]
        public bool CanBetting { get { return canBetting; } set { canBetting = value; } }      
        [Column(name: "Avatar")]
        public string Avatar { get { return avatar; } set { avatar = value; } }

        [Column(name: "Money")]
        public decimal Money { get { return money; } set { money = value; } }


    }
}
