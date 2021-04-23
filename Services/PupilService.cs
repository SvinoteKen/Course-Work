using School.Data;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    class PupilService : IPupilService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IRepository _repository;
        public PupilService()
        {
            _repository = _unitOfWork.Repository;
        }
        public IEnumerable<Pupil> GetPupil()
        {
            return _repository.GetPupils();
        }
        public void AddPupil(Pupil pupil)
        {
            _repository.AddPupil(pupil);
            _unitOfWork.SavePupils();
        }
        public void RemovePupil(int pupilId)
        {
            _repository.RemovePupil(pupilId);
            _unitOfWork.SavePupils();
        }
        public int GetMaxId()
        {
            return _repository.GetMaxIdPupil();
        }
        public void UpdatePupil(Pupil pupil, int pupilId)
        {
            _repository.UpdatePupil(pupil, pupilId);
            _unitOfWork.SavePupils();
        }
    }
}
