using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Repositories
{
    public interface ISchedulingRepository
    {
        Task<List<Scheduling>> GetAllAsync();

        Task AddAsync(Scheduling scheduling);
        Task<List<Scheduling>> GetByUserIdAsync(Guid UserId);
        Task<Scheduling> GetByIdAsync(Guid ScheduleId);
        Task SaveChangesAsync();
    }
}
