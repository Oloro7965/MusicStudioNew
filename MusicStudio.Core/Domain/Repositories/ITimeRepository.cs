using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Repositories
{
    public interface ITimeRepository
    {
        Task AddAsync(Time time);

        Task<List<Time>> GetAllAsync();

        Task<Time> GetByIdAsync(Guid id);

        Task SaveChangesAsync();
    }
}
