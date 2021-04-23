using School.Data;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IRepository _repository;
        public EventService()
        {
            _repository = _unitOfWork.Repository;
        }
        public IEnumerable<Event> GetEvent()
        {
            return _repository.GetEvents();
        }
        public void AddEvent(Event _event)
        {
            _repository.AddEvent(_event);
            _unitOfWork.SaveEvents();
        }
        public void RemoveEvent(int eventId)
        {
            _repository.RemoveEvent(eventId);
            _unitOfWork.SaveEvents();
        }
        public int GetMaxId()
        {
            return _repository.GetMaxIdEvent();
        }
        public void UpdateEvent(Event _event, int eventId)
        {
            _repository.UpdateEvent(_event, eventId);
            _unitOfWork.SaveEvents();
        }
    }
}
