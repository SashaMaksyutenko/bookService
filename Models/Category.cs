using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookService.Models
{
    public class Category
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage ="range must contain numbers from 1 to 1000 only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }

}