using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository  _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id);

            if (user is null)
            {
                return ResultViewModel.Error("usuário não encontrado");
            }

            user.Update(request.Email, request.PasswordHash);

            //_dbcontext.Update(user);  
            _userRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
