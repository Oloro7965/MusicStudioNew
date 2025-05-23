using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetAllSchedulingByUserIdQuery
{
    public class GetAllSchedulingByUserIdQueryHandler : IRequestHandler<GetAllSchedulingByUserIdQuery, ResultViewModel<List<ScheduleViewModel>>>
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public GetAllSchedulingByUserIdQueryHandler(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        public async Task<ResultViewModel<List<ScheduleViewModel>>> Handle(GetAllSchedulingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userSchedules = await _schedulingRepository.GetByUserIdAsync(request.UserId);
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            var schedulesViewModel = userSchedules.Select(b => new ScheduleViewModel(b.room,b.StartTime,b.EndTime,b.date))
                 .ToList();

            return ResultViewModel<List<ScheduleViewModel>>.Success(schedulesViewModel);
        }
    }
}
