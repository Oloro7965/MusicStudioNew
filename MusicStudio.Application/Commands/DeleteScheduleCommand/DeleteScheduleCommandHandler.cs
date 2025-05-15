using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.DeleteScheduleCommand
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, ResultViewModel>
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public DeleteScheduleCommandHandler(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _schedulingRepository.GetByIdAsync(request.Id);

            if (schedule is null)
            {
                return ResultViewModel.Error("Este Contato não existe");
            }
            schedule.Delete();

            await _schedulingRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
