using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Itis_bet.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Itis_bet.DAL.Models
{
    public class Articles
    {
        public Guid Id { get; set; }

        [Required]
        public Sport Sport { get; set; }
        
        [Required]
        [StringLength(64, MinimumLength = 4, 
            ErrorMessage = "Header must be less than 64 and more 4 symbols")]
        public string Header { get; set; }

        [Required (ErrorMessage = "Please set description")]
        [StringLength(255, MinimumLength = 4,
            ErrorMessage = "Description must be less than 255 and more 4 symbols")]
        public string Description { get; set; }
        
        [Required (ErrorMessage = "Its a consonance, post without content! ")]
        public string Content { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PublishedAt { get; set; }
        
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }
        
        public ICollection<Comments> Comments { get; set; }

        [BindNever] 
        public bool IsCommented => 
            Comments.Count != 0;
    }
}
