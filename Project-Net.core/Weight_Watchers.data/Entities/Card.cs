using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weight_Watchers.data.Entities
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public int? SubscriberId { get; set; }

        [ForeignKey(nameof(SubscriberId))]
        public Subscriber Subscriber { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }
        
        public double BMI { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
