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
            RoomId = salaId;
            this.room = room;
            StartTime = startTime;
            EndTime = endTime;
            date = dataEspecifica;
            IsAvailable = true;
        }

        public Guid RoomId { get; private set; }
        public Room room { get; private set; }

        //public DayOfWeek DiaSemana { get; set; } // Enum: Domingo, Segunda, etc.
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public DateTime date { get; private set; }
        public bool IsAvailable { get; private set; }
    }
}
