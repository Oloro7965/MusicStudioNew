using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateScheduleCommand
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ResultViewModel>
    {
        public Task<ResultViewModel> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
