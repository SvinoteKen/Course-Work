using School.Entities;
using System.Collections.Generic;

namespace School.Services
{
    interface IPupilService
    {
        void AddPupil(Pupil pupil);
        int GetMaxId();
        IEnumerable<Pupil> GetPupil();
        void RemovePupil(int pupilId);
        void UpdatePupil(Pupil pupil, int pupilId);
    }
}