using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicStudio.Application.Commands.CreateScheduleCommand
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ResultViewModel<object>>
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public CreateScheduleCommandHandler(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var scheduling = new Scheduling(request.UserId,
            request.TimeId, request.RoomId, request.StartTime, request.EndTime, request.Date);

            await _schedulingRepository.AddAsync(scheduling);

            return ResultViewModel<object>.Success(new { scheduling.Id });
        }
    }
}
