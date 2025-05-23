using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.DeleteSchedulingCommand
{
    public class DeleteSchedulingCommandHandler : IRequestHandler<DeleteSchedulingCommand, ResultViewModel>
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public DeleteSchedulingCommandHandler(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteSchedulingCommand request, CancellationToken cancellationToken)
        {
            var contact = await _schedulingRepository.GetByIdAsync(request.Id);

            if (contact is null)
            {
                return ResultViewModel.Error("Este Contato não existe");
            }
            contact.Delete();

            await _schedulingRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
