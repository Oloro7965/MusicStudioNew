using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.ViewModels
{
    public class ScheduleViewModel
    {
        public ScheduleViewModel(Room room, TimeSpan startTime, TimeSpan endTime, DateTime date)
        {
            this.room = room;
            StartTime = startTime;
            EndTime = endTime;
            this.date = date;
        }

        public Room room { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public DateTime date { get; private set; }
    }
}
