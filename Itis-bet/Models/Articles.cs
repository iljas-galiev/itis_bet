using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Itis_bet.Models
{
    public class Articles
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }
    }
}
