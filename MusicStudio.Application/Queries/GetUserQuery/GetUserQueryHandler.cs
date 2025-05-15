using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetUserQuery
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var contact = await _userRepository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                return ResultViewModel<UserViewModel>.Error("Este contato não existe");
            }

            var UserDetailViewModel = new UserViewModel(contact.Nome,contact.Email,contact.SenhaHash,contact.Role.ToString(),contact.Agendamentos);

            //var UserDetailViewModel = UserViewModel.FromEntity(user);
            return ResultViewModel<UserViewModel>.Success(UserDetailViewModel);
        }
    }
}
