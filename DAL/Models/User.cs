using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;


namespace DAL.Models
{
    public class User : IdentityUser
    {
        [Key]
        [DataType(DataType.EmailAddress)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public Guid ProfileId { get; set; }
        public UserProfile Profile { get; set; }

        public Guid  PassportId { get; set; }
        public Passport Passport { get; set; }

        public IEnumerable<Comments> Comments { get; set; }

    }
    
    public class UserProfile
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }

        public uint Money { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool CanBet { get; set; }
    }

    public class Passport
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string Serial { get; set; }
        public string Number { get; set; }
        public string Issued { get; set; }
    }
}