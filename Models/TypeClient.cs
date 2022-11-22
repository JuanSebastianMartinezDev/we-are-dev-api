﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeAreDevApi.Models
{
    public class TypeClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; } = 1;
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }

    }
}
