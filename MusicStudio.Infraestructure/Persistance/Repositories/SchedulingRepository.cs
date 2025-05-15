using Microsoft.EntityFrameworkCore;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Infraestructure.Persistance.Repositories
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly MusicStudioDbContext _dbcontext;

        public SchedulingRepository(MusicStudioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Scheduling scheduling)
        {
            await _dbcontext.Schedulings.AddAsync(scheduling);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Scheduling>> GetAllAsync()
        {
            return await _dbcontext.Schedulings.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }

        public async Task<Scheduling> GetByIdAsync(Guid ScheduleId)
        {
            return await _dbcontext.Schedulings.Where(c => c.IsDeleted.Equals(false) && c.Id == ScheduleId)
                .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
