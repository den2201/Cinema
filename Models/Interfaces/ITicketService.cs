using Cinema.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models.Interfaces
{
    interface ITicketService
    {
        Film GetFilmById(int id);
        IEnumerable<Film> GetAllFilms();

        Hall GetHallById(int id);
        IEnumerable<Hall> GetAllHalls();

        TimeSlot GetTimeSlotById(int id);
        IEnumerable<TimeSlot> GetAllTimeSlots();

        bool UpdateFilm(Film film);



    }
}
