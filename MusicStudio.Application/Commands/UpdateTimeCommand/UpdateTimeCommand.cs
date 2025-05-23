using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.UpdateTimeCommand
{
    public class UpdateTimeCommand: IRequest<ResultViewModel>
    {
        public Guid id { get; set; }
        public TimeSpan StartTime { get;  set; }
        public TimeSpan EndTime { get;  set; }
        public DateTime date { get; set; }
    }
}
