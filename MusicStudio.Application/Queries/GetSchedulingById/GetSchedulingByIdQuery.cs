using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetSchedulingById
{
    public class GetSchedulingByIdQuery: IRequest<ResultViewModel<ScheduleViewModel>>
    {
        public GetSchedulingByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
