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
    public class RoomRepository : IRoomRepository
    {
        private readonly MusicStudioDbContext _dbcontext;

        public RoomRepository(MusicStudioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Room room)
        {
            await _dbcontext.Rooms.AddAsync(room);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _dbcontext.Rooms.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }

        public async Task<Room> GetByIdAsync(Guid id)
        {

            return await _dbcontext.Rooms.Where(c => c.IsDeleted.Equals(false) && c.Id == id)

            .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
