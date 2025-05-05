using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Entities
{
    public class Time:BaseEntity
    {
        public Time(Guid salaId, Room room, TimeSpan startTime, TimeSpan endTime, DateTime dataEspecifica)
        {
            SalaId = salaId;
            this.room = room;
            StartTime = startTime;
            EndTime = endTime;
            date = dataEspecifica;
        }

        public Guid SalaId { get; private set; }
        public Room room { get; private set; }

        //public DayOfWeek DiaSemana { get; set; } // Enum: Domingo, Segunda, etc.
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        // Se quiser controlar disponibilidade por data específica:
        public DateTime date { get; private set; }
    }
}
