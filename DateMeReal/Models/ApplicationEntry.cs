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
        [Required (ErrorMessage = "Must enter movie name")]
        public string MovieName { get; set; }
        [Required (ErrorMessage = "Must enter movie year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Must enter director")]
        public string Director { get; set; }
        [Required (ErrorMessage = "Must enter rating")]
        public string Rating { get; set; }
        public string LentTo { get; set; }
        public bool Edited { get; set; }
        public string Notes { get; set; }

        // set up foreign key relationship
        [Required(ErrorMessage = "Must enter movie category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; } //set an instance of type category

    }
}
