using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Infraestructure.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.RegisteredSchedules).
                WithOne(x => x.room).
                HasForeignKey(x => x.RoomId).
                OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.RegisteredTimes).
                WithOne(x => x.room).
                HasForeignKey(x => x.RoomId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
