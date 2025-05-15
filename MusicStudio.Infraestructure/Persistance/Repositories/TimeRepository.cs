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
    }
}
