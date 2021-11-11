using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW5Project.Models
{
    public partial class Assignments
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Range(1,9)]
        public int Priority { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Course { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Notes { get; set; }
    }
}
