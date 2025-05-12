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
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }  // Armazenar hash, nunca a senha pura
        public EUserRole Role { get; private set; }

        // Navegação opcional, como Lista de Agendamentos
        public List<Scheduling> Agendamentos { get; set; }
    }
}
