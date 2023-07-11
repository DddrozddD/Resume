using DAL.Models;
using DAL.Repositories.UnitsOfWork;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ExperienceService
    {


        private readonly IUnitOfWork unitOfWork;

        public ExperienceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Experience>> GetAsyncs() => await unitOfWork.ExperienceRepository.GetAllAsync();
        public async Task<IReadOnlyCollection<Experience>> FindByConditionAsync(Expression<Func<Experience, bool>> predicat) => await this.unitOfWork.ExperienceRepository.FindByConditionAsync(predicat);
        public async Task<Experience> FindByConditionItemAsync(Expression<Func<Experience, bool>> predicat) => await this.unitOfWork.ExperienceRepository.FindByConditionItemAsync(predicat);
        public async Task<OperationDetails> CreateAsync(Experience experience) => await unitOfWork.ExperienceRepository.CreateAsync(experience);
        public async Task DeleteAsync(int id) => await unitOfWork.ExperienceRepository.Delete(id);
        public async Task EditAsync(int id, Experience experience) => await unitOfWork.ExperienceRepository.Update(experience, id);
    }
}
