using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Entities
{
    public class Scheduling : BaseEntity
    {
        public Scheduling(Guid userId, 
            Guid timeId, Guid roomId,TimeSpan startTime, TimeSpan endTime, DateTime date)
        {
            UserId = userId;
            TimeId = timeId;
            RoomId = roomId;
            StartTime = startTime;
            EndTime = endTime;
            this.date = date;
            IsDeleted = false;
        }

        public Guid UserId { get; private set; }
        public User user { get; private set; }
        public Time ScheduledTime { get; private set; }
        public Guid TimeId { get; private set; }
        public Guid RoomId { get; private set; }
        public Room room { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public DateTime date { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
