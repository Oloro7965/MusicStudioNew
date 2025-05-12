using Microsoft.EntityFrameworkCore;
using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Infraestructure.Persistance
{
    public class MusicStudioDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Scheduling> Schedulings { get; set; }

        public DbSet<Time> TimesScheduled { get; set; }


        public MusicStudioDbContext(DbContextOptions<MusicStudioDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
