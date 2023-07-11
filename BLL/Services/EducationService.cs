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
    public class EducationService
    {
       
            private readonly IUnitOfWork unitOfWork;

            public EducationService(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<IReadOnlyCollection<Education>> GetAsyncs() => await unitOfWork.EducationRepository.GetAllAsync();
            public async Task<IReadOnlyCollection<Education>> FindByConditionAsync(Expression<Func<Education, bool>> predicat) => await this.unitOfWork.EducationRepository.FindByConditionAsync(predicat);
            public async Task<Education> FindByConditionItemAsync(Expression<Func<Education, bool>> predicat) => await this.unitOfWork.EducationRepository.FindByConditionItemAsync(predicat);
            public async Task<OperationDetails> CreateAsync(Education education) => await unitOfWork.EducationRepository.CreateAsync(education);
            public async Task DeleteAsync(int id) => await unitOfWork.EducationRepository.Delete(id);
            public async Task EditAsync(int id, Education education) => await unitOfWork.EducationRepository.Update(education, id);
        
    }
}
