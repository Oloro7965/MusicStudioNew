using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.DeleteScheduleCommand
{
    public class DeleteScheduleCommand:IRequest<ResultViewModel>
    {
        public DeleteScheduleCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
