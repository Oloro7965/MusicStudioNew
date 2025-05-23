using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.DeleteTimeCommand
{
    public class DeleteTimeCommand: IRequest<ResultViewModel>
    {
        public DeleteTimeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
