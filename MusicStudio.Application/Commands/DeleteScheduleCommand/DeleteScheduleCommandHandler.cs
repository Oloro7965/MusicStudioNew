using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.DeleteScheduleCommand
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, ResultViewModel>
    {
        public Task<ResultViewModel> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
