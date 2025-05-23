using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetRoomQuery
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, ResultViewModel<RoomViewModel>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ResultViewModel<RoomViewModel>> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.Id);
            if (room is null)
            {
                return ResultViewModel<RoomViewModel>.Error("Este contato não existe");
            }

            var RoomDetailViewModel = new RoomViewModel(room.Name,room.RegisteredSchedules,room.IsDeleted);

            //var UserDetailViewModel = UserViewModel.FromEntity(user);
            return ResultViewModel<RoomViewModel>.Success(RoomDetailViewModel);
        }
    }
}
