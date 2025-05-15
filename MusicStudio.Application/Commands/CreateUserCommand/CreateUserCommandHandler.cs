using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,ResultViewModel<object>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name,request.Email,request.SenhaHash,request.Role);

            await _userRepository.AddAsync(user);

            return ResultViewModel<object>.Success(new { user.Id });
        }
    }
}
