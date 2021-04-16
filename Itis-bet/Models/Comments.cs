using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Itis_bet.Models
{
    public class Comments
    {
        public Guid Id { get; set; }


        public Guid User_Id { get; set; }
        [ForeignKey("User_Id")]
        public Users User { get; set; }

        public Guid Article_Id { get; set; }
        [ForeignKey("Article_Id")]
        public Articles Article { get; set; }

        [Required]
        public string Text { get; set; }

        public Guid? ReplyTo { get; set; }
        [ForeignKey("ReplyTo")]
        public Comments Comment { get; set; }
    }
}
