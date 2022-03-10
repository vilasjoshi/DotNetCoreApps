using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Cannot Be more than 100")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
