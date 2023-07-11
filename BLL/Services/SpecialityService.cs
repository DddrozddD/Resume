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
    public class SpecialityService
    {
        private readonly IUnitOfWork unitOfWork;
        

        public SpecialityService(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Speciality>> GetAsyncs() => await unitOfWork.SpecialityRepository.GetAllAsync();
        public async Task<IReadOnlyCollection<Speciality>> FindByConditionAsync(Expression<Func<Speciality, bool>> predicat) => await this.unitOfWork.SpecialityRepository.FindByConditionAsync(predicat);
        public async Task<Speciality> FindByConditionItemAsync(Expression<Func<Speciality, bool>> predicat) => await this.unitOfWork.SpecialityRepository.FindByConditionItemAsync(predicat);
        public async Task<OperationDetails> CreateAsync(Speciality resume) => await unitOfWork.SpecialityRepository.CreateAsync(resume);
        public async Task DeleteAsync(int id) => await unitOfWork.SpecialityRepository.Delete(id);
        public async Task EditAsync(int id, Speciality resume) => await unitOfWork.SpecialityRepository.Update(resume, id);
    }
}
