using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetAllRoomsQuery
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, ResultViewModel<List<RoomViewModel>>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ResultViewModel<List<RoomViewModel>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            var roomViewModel = rooms.Select(b => new RoomViewModel(b.Name,b.RegisteredTimes,b.IsDeleted))
                 .ToList();

            return ResultViewModel<List<RoomViewModel>>.Success(roomViewModel);
        }
    }
}
