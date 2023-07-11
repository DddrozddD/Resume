using DAL.Context;
using DAL.Models;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EducationRepository:BaseRepository<Education>
    {
        public EducationRepository(ResumeContext context) : base(context)
        {
        }

        public async Task Delete(int id)
        {
            var education = await this.Entities.FirstOrDefaultAsync(e => e.Id == id).ConfigureAwait(false);
            if (education != null)
            {
                this.Entities.Remove(education);
            }
            await _context.SaveChangesAsync();

        }
        public async Task<OperationDetails> Update(Education education, int Id)
        {
            var model = this.Entities.Where(e => e.Id == Id).First();
            model.NameOfUniversaty = education.NameOfUniversaty;
            model.Description= education.Description;
            model.Year = education.Year;
            model.resumeId = education.resumeId;
            model.Speciality = education.Speciality;

            this._context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();

            return new OperationDetails() { IsError = false };
        }
    }
}
