﻿using Microsoft.EntityFrameworkCore;
using MusicStudio.Core.Domain.Entities;
using MusicStudio.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Infraestructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicStudioDbContext _dbcontext;

        public UserRepository(MusicStudioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(User user)
        {
            await _dbcontext.Users.AddAsync(user);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbcontext.Users.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
            //return await _dbcontext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {

            //return await _dbcontext.Users.Where(c => c.IsDeleted.Equals(false) && c.Id == id).Include(c => c.FieldWork)

            //.SingleOrDefaultAsync();
            return await _dbcontext.Users.Where(c => c.Id == id)

            .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
