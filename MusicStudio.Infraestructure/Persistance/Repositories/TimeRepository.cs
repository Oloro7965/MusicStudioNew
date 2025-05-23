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
    public class TimeRepository : ITimeRepository
    {
        private readonly MusicStudioDbContext _dbcontext;

        public TimeRepository(MusicStudioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Time time)
        {
            await _dbcontext.TimesScheduled.AddAsync(time);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Time>> GetAllAsync()
        {
            return await _dbcontext.TimesScheduled.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }

        public async Task<Time> GetByIdAsync(Guid id)
        {
            return await _dbcontext.TimesScheduled.Where(c => c.Id == id)

            .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
