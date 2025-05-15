using MediatR;
using MusicStudio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.Commands.UpdateUserCommand
{
    public class UpdateUserCommand:IRequest<ResultViewModel>
    {
        public Guid id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
