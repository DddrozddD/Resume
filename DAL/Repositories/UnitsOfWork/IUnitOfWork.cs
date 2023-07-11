using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitsOfWork
{
    public interface IUnitOfWork
    {
        SkillRepository SkillRepository { get; }
        ResumeRepository ResumeRepository { get; }
        SpecialityRepository SpecialityRepository { get; }
        EducationRepository EducationRepository { get; }
        ExperienceRepository ExperienceRepository { get; }
    }
}
