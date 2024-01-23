using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ProektnaZadaca.Models.Ticket;

namespace ProektnaZadaca.Models
{
    [Table("Time")]
    public class Time
    {
        [Key]
        public int timeId { get; set; }
        [ForeignKey("Flight")]
        public int flightId { get; set; }

        [Required]
        [Display(Name = "From")]
        public string fromLocation { get; set; }

        [Required]
        [Display(Name = "Destination")]
        public string dest { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Departure date")]
        public DateTime departureDate { get; set; }
        [Required]
        [Display(Name = "Departure time")]
        public TimeSpan depatureTime { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }

    }
}