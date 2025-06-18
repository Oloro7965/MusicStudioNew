using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Core.Domain.Entities
{
    public class Room:BaseEntity
    {
        public Room(string name)
        {
            Name = name;
            RegisteredTimes = new List<Time>();
            RegisteredSchedules = new List<Scheduling>();
            IsDeleted = false;
        }

        public string Name { get; private set; }
        public List<Time> RegisteredTimes { get; private set; }
        public List<Scheduling> RegisteredSchedules { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
