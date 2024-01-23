using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProektnaZadaca.Models
{
        public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                var flight = new List<Flight>
            {
                new Flight {flightId = 1, flightName = "British Airways", price = 200, totalSeats = 200},
                new Flight {flightId = 2, flightName = "Qatar Airways", price = 300, totalSeats = 300},
                new Flight {flightId = 3, flightName = "Singapore Airlines", price = 400, totalSeats = 250},
                new Flight {flightId = 4, flightName = "AirAsia", price = 200, totalSeats = 280},
                new Flight {flightId = 5, flightName = "Emirates", price = 300, totalSeats = 240},
                new Flight {flightId = 6, flightName = "Etihad", price = 400, totalSeats = 260},
                new Flight {flightId = 7, flightName = "Qantas Airways", price = 500, totalSeats = 257},
                new Flight {flightId = 8, flightName = "Japan Airlines", price = 600, totalSeats = 190},
                new Flight {flightId = 9, flightName = "Turkish Airlines", price = 700, totalSeats = 238},
                new Flight {flightId = 10, flightName = "Air France", price = 300, totalSeats = 197},
            };

                flight.ForEach(s => context.Flight.Add(s));
                context.SaveChanges();

            var time = new List<Time>
            {
                new Time { timeId = 1,  flightId =1, dest = "Kansas",  departureDate = new DateTime(2023,10, 17) , depatureTime = new TimeSpan(7,14, 18)},
                new Time { timeId = 2,  flightId =1, dest = "Kansas",  departureDate = new DateTime(2023,12, 18), depatureTime = new TimeSpan(6,14, 18) },
                new Time { timeId = 3,  flightId =1, dest = "Kansas",  departureDate = new DateTime(2023,04, 20), depatureTime = new TimeSpan(5,14, 18) },
                new Time { timeId = 4,  flightId =1, dest = "Kansas",  departureDate = new DateTime(2023,01, 01), depatureTime = new TimeSpan(4,14, 18) },
                new Time { timeId = 5,  flightId =1, dest = "Kansas",  departureDate = new DateTime(2023,02, 14), depatureTime = new TimeSpan(3,14, 18) },
                new Time { timeId = 6,  flightId =2, dest = "Illinois", departureDate = new DateTime(2023,12, 07), depatureTime = new TimeSpan(2,14, 18)},
                new Time { timeId = 6,  flightId =2, dest = "Illinois", departureDate = new DateTime(2023,12, 08), depatureTime = new TimeSpan(1,14, 18)},
                new Time { timeId = 7,  flightId =2, dest = "Illinois", departureDate = new DateTime(2023,12, 13), depatureTime = new TimeSpan(2,14, 18)},
                new Time { timeId = 8,  flightId =2, dest = "Illinois", departureDate = new DateTime(2023,03, 04), depatureTime = new TimeSpan(3,14, 18)},
                new Time { timeId = 9,  flightId =2, dest = "Illinois", departureDate = new DateTime(2023,05, 01), depatureTime = new TimeSpan(4,14, 18)},
                new Time { timeId = 10, flightId =3, dest = "California", departureDate = new DateTime(2023,07, 21), depatureTime = new TimeSpan(5,14, 18)},
            };

                time.ForEach(s => context.Time.Add(s));
                context.SaveChanges();

                var ticket = new List<Ticket>
            {
            new Ticket{ticketId = 1, flightId = 1, scheduleId = 1, dateOfJourney = new DateTime(2023,10, 17), gender = 'F', phoneNumber = "078928198"},
            new Ticket{ticketId = 2, flightId = 1, scheduleId = 1, dateOfJourney = new DateTime(2023,12, 18),  gender = 'F', phoneNumber = "077928198"},
            new Ticket{ticketId = 3, flightId = 3, scheduleId = 10, dateOfJourney = new DateTime(2023,04, 20), gender = 'M', phoneNumber = "071568198"},
            new Ticket{ticketId = 4, flightId = 3, scheduleId = 14, dateOfJourney = new DateTime(2023,01, 01), gender = 'F', phoneNumber = "072978654"},
            new Ticket{ticketId = 5, flightId = 4, scheduleId = 19, dateOfJourney = new DateTime(2023,02, 14), gender = 'M', phoneNumber = "0704554786"}
            };
                ticket.ForEach(s => context.Ticket.Add(s));
                context.SaveChanges();

            }
        }
    }