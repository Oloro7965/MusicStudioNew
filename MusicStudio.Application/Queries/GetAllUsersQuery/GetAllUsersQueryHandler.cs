using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            var userViewModel = users.Select(b => new UserViewModel(b.Nome,b.Email,b.SenhaHash,b.Role.ToString(),b.Agendamentos))
                 .ToList();

            return ResultViewModel<List<UserViewModel>>.Success(userViewModel);
        }
    }
}
