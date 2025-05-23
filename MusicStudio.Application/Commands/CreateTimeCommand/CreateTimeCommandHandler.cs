using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateTimeCommand
{
    public class CreateTimeCommandHandler : IRequestHandler<CreateTimeCommand, ResultViewModel<object>>
    {
        private readonly ITimeRepository _timeRepository;

        public CreateTimeCommandHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateTimeCommand request, CancellationToken cancellationToken)
        {
            var time = new Time(request.RoomId,request.StartTime,request.EndTime,request.date);

            await _timeRepository.AddAsync(time);

            return ResultViewModel<object>.Success(new { time.Id });
        }
    }
}
