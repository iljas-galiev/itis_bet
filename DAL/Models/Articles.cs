using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
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
        
        /* !!! Auto Generated, please dont configure selfly. !!! */
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
