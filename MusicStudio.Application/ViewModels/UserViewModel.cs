using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string nome, string email, string senhaHash, string role, List<Scheduling> agendamentos)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Role = role;
            Agendamentos = agendamentos;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; } 
        public string Role { get; private set; }

        
        public List<Scheduling> Agendamentos { get; private set; }
    }
}
