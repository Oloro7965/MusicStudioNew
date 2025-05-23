using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.DeleteTimeCommand
{
    public class DeleteTimeCommandHandler : IRequestHandler<DeleteTimeCommand, ResultViewModel>
    {
        private readonly ITimeRepository _timeRepository;

        public DeleteTimeCommandHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteTimeCommand request, CancellationToken cancellationToken)
        {
            var time = await _timeRepository.GetByIdAsync(request.Id);

            if (time is null)
            {
                return ResultViewModel.Error("Este usuário não existe");
            }
            time.Delete();

            await _timeRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
