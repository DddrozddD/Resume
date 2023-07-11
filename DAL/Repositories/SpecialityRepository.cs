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
    public class SpecialityRepository:BaseRepository<Speciality>
    {
        public SpecialityRepository(ResumeContext context) : base(context)
        {
        }

        public async Task Delete(int id)
        {
            var speciality = await this.Entities.FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (speciality != null)
            {
                this.Entities.Remove(speciality);
            }
            await _context.SaveChangesAsync();

        }
        public async Task<OperationDetails> Update(Speciality speciality, int Id)
        {
            var model = this.Entities.Where(m => m.Id == Id).First();
            model.Name = speciality.Name;
            model.resumeId = speciality.resumeId;

            this._context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();

            return new OperationDetails() { IsError = false };
        }
    }
}
