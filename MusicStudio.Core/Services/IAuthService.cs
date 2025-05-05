using MusicStudio.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Services
{
    public interface IAuthService
    {
        string ComputeHash(string password);
        string GenerateToken(string email, EUserRole role);


    }
}
