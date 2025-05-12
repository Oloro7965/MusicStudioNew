using MediatR;
using MusicStudio.Application.ViewModels;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResultViewModel>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public EUserRole Role { get; set; }
    }
}
