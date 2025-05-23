using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetAllSchedulingByUserIdQuery
{
    public class GetAllSchedulingByUserIdQuery : IRequest<ResultViewModel<List<ScheduleViewModel>>>
    {
        public GetAllSchedulingByUserIdQuery(Guid userid)
        {
            UserId = userid;
        }

        public Guid UserId { get; private set; }
}
}
