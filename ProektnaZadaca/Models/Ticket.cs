using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProektnaZadaca.Models
{
    public enum Destination
    {
        London,
        Qatar,
        Singapore,
        Shanghai,
        [Display(Name = "Abu Dhabi")]
        AbuDhabi,
        Warsaw,
        Melbourne,
        Kyoto,
        Istanbul,
        Paris,
    }
    public enum IsReturn
    {
        Yes,
        No
    }

    public enum Package
    {
        Basic,
        Standard,
        Premium
    }

    [Table("Ticket")]
        public class Ticket
        {
            [Required]
            [Key]
            public int ticketId { get; set; }
            [ForeignKey("Flight")]
            public int flightId { get; set; }
            [ForeignKey("Time")]
            public int scheduleId { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public Destination? destination { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date of journey")]
            public DateTime dateOfJourney { get; set; }
        [Required]
        [Display(Name = "Full name")]
            public string nameAndSurname { get; set; }
        [Required]
        [Display(Name = "Gender")]
            public char gender { get; set; }
        [Required]
        [Phone]
            [Display(Name = "Phone number")]
            public string phoneNumber { get; set; }
        [Required]
        [Display(Name = "Address")]
            public string address { get; set; }
        [Required]
        [Display(Name = "Return ticket")]
            public IsReturn? isReturn { get; set; }
        [Required]
            [Display(Name = "Package")]
            public Package? package { get; set; }
        public virtual Flight Flight { get; set; }
            public virtual Time Time{ get; set; }
        }
    }