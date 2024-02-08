using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Watchers.core.DTO
{
    public class cardDTO
    {
        public int? SubscriberId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
