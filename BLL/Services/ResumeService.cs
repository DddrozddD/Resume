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
    public class ResumeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailSender emailSender;

        public ResumeService(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            this.unitOfWork = unitOfWork;
            this.emailSender = emailSender;
        }

        public async Task<IReadOnlyCollection<Resume>> GetAsyncs() => await unitOfWork.ResumeRepository.GetAllAsync();
        public async Task<IReadOnlyCollection<Resume>> FindByConditionAsync(Expression<Func<Resume, bool>> predicat) => await this.unitOfWork.ResumeRepository.FindByConditionAsync(predicat);
        public async Task<Resume> FindByConditionItemAsync(Expression<Func<Resume, bool>> predicat) => await this.unitOfWork.ResumeRepository.FindByConditionItemAsync(predicat);
        public async Task<OperationDetails> CreateAsync(Resume resume) => await unitOfWork.ResumeRepository.CreateAsync(resume);
        public async Task DeleteAsync(int id) => await unitOfWork.ResumeRepository.Delete(id);
        public async Task EditAsync(int id, Resume resume) => await unitOfWork.ResumeRepository.Update(resume, id);
    }
}
