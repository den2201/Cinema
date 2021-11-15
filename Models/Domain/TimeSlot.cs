using System;

namespace Cinema.Models.Domain
{
    public class TimeSlot
    {
        public int Id { get; set; }
        
        public DateTime StartTime { get; set; }  
        
        public Decimal Cost { get; set; }

        public Movie Movie { get; set; }

        public Hall Hall { get; set; }

        public Format Format { get; set; }

    }
}

