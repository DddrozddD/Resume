using DAL.Models;
using DAL.Repositories.UnitsOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkillService
    {
        private readonly IUnitOfWork unitOfWork;
       
        public SkillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Skill>> GetAsyncs() => await unitOfWork.SkillRepository.GetAllAsync();
        public async Task<IReadOnlyCollection<Skill>> FindByConditionAsync(Expression<Func<Skill, bool>> predicat) => await this.unitOfWork.SkillRepository.FindByConditionAsync(predicat);
        public async Task<OperationDetails> CreateAsync(Skill skill) => await unitOfWork.SkillRepository.CreateAsync(skill);
        public async Task DeleteAsync(int id) => await unitOfWork.SkillRepository.Delete(id);
        public async Task EditAsync(int id, Skill skill) => await unitOfWork.SkillRepository.Update(skill, id);
    }
}
