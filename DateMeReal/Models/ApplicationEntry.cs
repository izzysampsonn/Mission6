using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateMeReal.Models
{
    public class ApplicationEntry
    {
        [Key]
        [Required]
        public int EntryId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string LentTo { get; set; }
        public bool Edited { get; set; }
        public string Notes { get; set; }

    }
}
