using Cinema.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class FileModel
    {
       public Film [] Films { get; set; }

       public Hall [] Halls { get; set; }

       public TimeSlot [] TimeSlots { get; set; }
    }
}