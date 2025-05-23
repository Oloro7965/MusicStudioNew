using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateRoomCommand
{
    public class CreateRoomCommand: IRequest<ResultViewModel<object>>
    {
        public string Name { get;  set; }
    }
}
