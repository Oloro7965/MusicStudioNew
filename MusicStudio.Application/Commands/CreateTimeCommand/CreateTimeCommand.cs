using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateTimeCommand
{
    public class CreateTimeCommand: IRequest<ResultViewModel<object>>
    {
        public Guid RoomId { get;  set; }
        public TimeSpan StartTime { get;  set; }
        public TimeSpan EndTime { get; set; }
        public DateTime date { get; set; }
    }
}
