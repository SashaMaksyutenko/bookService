﻿using System;
using System.ComponentModel.DataAnnotations;

namespace bookService.Models
{
    public class Category
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.MinValue;

    }

}