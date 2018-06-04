using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public string Event { get; set; }
        public int IdPlace { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
