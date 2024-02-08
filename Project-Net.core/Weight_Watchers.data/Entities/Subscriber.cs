using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weight_Watchers.data.Entities
{
    [Table("Subscribers")]
    public class Subscriber
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MinLength(2)]
        public string FirstName { get; set; }

        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.[\w]{2,3})+)$", ErrorMessage = "Invalid Email!!")]
        public string Email { get; set; }

        [MinLength(4)]
        public string Password { get; set; }
    }
}
