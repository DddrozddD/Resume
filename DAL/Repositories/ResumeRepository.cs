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
    public class ResumeRepository : BaseRepository<Resume>
    {
        public ResumeRepository(ResumeContext context) : base(context)
        {
        }

        public async Task Delete(int id)
        {
            var resume = await this.Entities.FirstOrDefaultAsync(r => r.Id == id).ConfigureAwait(false);
            if (resume != null)
            {
                this.Entities.Remove(resume);
            }
            await _context.SaveChangesAsync();

        }
        public async Task<OperationDetails> Update(Resume resume, int Id)
        {
            var model = this.Entities.Where(r => r.Id == Id).First();
            model.About = resume.About;
            model.LinkOnRep= resume.LinkOnRep;
            model.userId = model.userId;

            this._context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();

            return new OperationDetails() { IsError = false };
        }
    }
}
