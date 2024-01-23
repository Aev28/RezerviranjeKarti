using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace ProektnaZadaca.Models
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        [Required]
        public int flightId { get; set; }
        [Required]
        [Display(Name = "Company name")]
        public string flightName { get; set; }

        [Required]
        [Display(Name = "Total seats")]
        public int totalSeats { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float price { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<Time> Time { get; set; }
    }
}