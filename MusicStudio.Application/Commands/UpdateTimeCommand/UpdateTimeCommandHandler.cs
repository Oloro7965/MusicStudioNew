using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.UpdateTimeCommand
{
    public class UpdateTimeCommandHandler : IRequestHandler<UpdateTimeCommand, ResultViewModel>
    {
        private readonly ITimeRepository _timeRepository;

        public UpdateTimeCommandHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateTimeCommand request, CancellationToken cancellationToken)
        {
            var time = await _timeRepository.GetByIdAsync(request.id);

            if (time is null)
            {
                return ResultViewModel.Error("usuário não encontrado");
            }

            time.Update(request.StartTime,request.EndTime,request.date);

            //_dbcontext.Update(user);  
            _timeRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
