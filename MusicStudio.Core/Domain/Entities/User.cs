using MusicStudio.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Entities
{
    public class User:BaseEntity
    {
        public User(string nome, string email, string senhaHash, EUserRole role)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Role = role;
            Agendamentos = new List<Scheduling>();
            IsDeleted = false;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }  // Armazenar hash, nunca a senha pura
        public EUserRole Role { get; private set; }

        // Navegação opcional, como Lista de Agendamentos
        public List<Scheduling> Agendamentos { get; set; }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string email, string password)
        {
            Email = email;

            SenhaHash = password;

        }
    }
}
