using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateRoomCommand
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, ResultViewModel<object>>
    {
        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room(request.Name);

            await _roomRepository.AddAsync(room);

            return ResultViewModel<object>.Success(new { room.Id });
        }
    }
}
