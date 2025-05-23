using MusicStudio.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Application.ViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel(string name, List<Time> registeredSchedules, bool isDeleted)
        {
            Name = name;
            RegisteredSchedules = registeredSchedules;
            IsDeleted = isDeleted;
        }

        public string Name { get; private set; }
        public List<Time> RegisteredSchedules { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
