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
            AvailableSchedules = new List<Time>();
        }

        public string Name { get; set; }
        public List<Time> AvailableSchedules { get; private set; }
    }
}
