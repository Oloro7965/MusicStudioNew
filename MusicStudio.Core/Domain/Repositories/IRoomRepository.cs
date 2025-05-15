using Microsoft.AspNetCore.Mvc;
using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();

        Task<Room> GetByIdAsync(Guid id);

        Task AddAsync(Room room);

        Task SaveChangesAsync();
    }
}
