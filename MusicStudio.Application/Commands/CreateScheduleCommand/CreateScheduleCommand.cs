using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateScheduleCommand
{
    public class CreateScheduleCommand: IRequest<ResultViewModel>
    {
        public Guid UserId { get;  set; }
        //public Time ScheduledTime { get; private set; }
        public Guid TimeId { get; set; }
        public Guid RoomId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime date { get;  set; }
    }
}
