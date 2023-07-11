using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       public SkillRepository SkillRepository { get; }
        public ResumeRepository ResumeRepository { get; }
        public SpecialityRepository SpecialityRepository { get; }
        public EducationRepository EducationRepository { get; }
        public ExperienceRepository ExperienceRepository { get; }
        public UnitOfWork(SkillRepository skillRepository, ResumeRepository resumeRepository, SpecialityRepository specialityRepository,
            EducationRepository educationRepository, ExperienceRepository experienceRepository)
        {
           SkillRepository = skillRepository;
            ResumeRepository = resumeRepository;
            SpecialityRepository = specialityRepository;
            EducationRepository = educationRepository;
            ExperienceRepository = experienceRepository;
        }

        
    }
}
