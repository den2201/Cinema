using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.Domain
{
    // сеанс фильма(время.. зал..фильм и цена)
    public class TimeSlot
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Cost { get; set; }

        public Film Film { get; set; }

        public Format format { get; set; }

        public Hall Hall { get; set; }

    }
}