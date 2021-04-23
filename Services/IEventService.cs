using School.Entities;
using System.Collections.Generic;

namespace School.Services
{
    interface IEventService
    {
        void AddEvent(Event _event);
        IEnumerable<Event> GetEvent();
        int GetMaxId();
        void RemoveEvent(int eventId);
        void UpdateEvent(Event _event, int eventId);
    }
}