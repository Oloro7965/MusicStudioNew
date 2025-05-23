using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetSchedulingById
{
    public class GetSchedulingByIdQueryHandler : IRequestHandler<GetSchedulingByIdQuery, ResultViewModel<ScheduleViewModel>>
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public GetSchedulingByIdQueryHandler(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        public async Task<ResultViewModel<ScheduleViewModel>> Handle(GetSchedulingByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _schedulingRepository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                return ResultViewModel<ScheduleViewModel>.Error("Este contato não existe");
            }

            var ScheduleDetailViewModel = new ScheduleViewModel(contact.room,contact.StartTime,contact.EndTime,contact.date);

            //var UserDetailViewModel = UserViewModel.FromEntity(user);
            return ResultViewModel<ScheduleViewModel>.Success(ScheduleDetailViewModel);
        }
    }
}
