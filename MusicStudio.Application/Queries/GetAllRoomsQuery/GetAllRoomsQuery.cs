using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetAllRoomsQuery
{
    public class GetAllRoomsQuery: IRequest<ResultViewModel<List<RoomViewModel>>>
    {
    }
}
