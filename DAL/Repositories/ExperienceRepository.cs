using DAL.Context;
using DAL.Models;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ExperienceRepository:BaseRepository<Experience>
    {

        public ExperienceRepository(ResumeContext context) : base(context)
        {
        }

        public async Task Delete(int id)
        {
            var experience = await this.Entities.FirstOrDefaultAsync(e => e.Id == id).ConfigureAwait(false);
            if (experience != null)
            {
                this.Entities.Remove(experience);
            }
            await _context.SaveChangesAsync();

        }
        public async Task<OperationDetails> Update(Experience experience, int Id)
        {
            var model = this.Entities.Where(e => e.Id == Id).First();
            model.NameOfCompany = experience.NameOfCompany;
            model.Description = experience.Description;
            model.Year = experience.Year;
            model.resumeId = experience.resumeId;
            model.Speciality = experience.Speciality;

            this._context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();

            return new OperationDetails() { IsError = false };
        }
    }
}
