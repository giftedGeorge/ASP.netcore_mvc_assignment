﻿using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    //abstract class that holds the common fields
    public abstract class ModelsAbstract
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string brand { get; set; }
    }
}
