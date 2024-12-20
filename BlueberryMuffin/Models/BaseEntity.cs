﻿using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public BaseEntity()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
