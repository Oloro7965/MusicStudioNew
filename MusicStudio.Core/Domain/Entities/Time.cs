using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Entities
{
    public class Time:BaseEntity
    {
        public Time(Guid salaId, TimeSpan startTime, TimeSpan endTime, DateTime date)
        {
            RoomId = salaId;
            this.room = room;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            IsAvailable = true;
            IsDeleted = false;
        }
        public Time() { }
        public Guid RoomId { get; private set; }
        public Room room { get; private set; }

        //public DayOfWeek DiaSemana { get; set; } // Enum: Domingo, Segunda, etc.
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsAvailable { get; private set; }
        public bool IsDeleted { get; private set; }
        public void Update(TimeSpan startTimeNew,TimeSpan endTimeNew,DateTime newDate)
        {
            StartTime = startTimeNew;
            EndTime = endTimeNew;
            Date = newDate;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
