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
    public class SkillRepository : BaseRepository<Skill>
    {
        public SkillRepository(ResumeContext context) : base(context)
        {
        }

        public async Task Delete(int id)
        {
            var skill = await this.Entities.FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
            if (skill != null)
            {
                this.Entities.Remove(skill);
            }
            await _context.SaveChangesAsync();

        }
        public async Task<OperationDetails> Update(Skill skill, int Id)
        {
            var model = this.Entities.Where(s => s.Id == Id).First();
            model.Name = skill.Name;
            model.resumeId = skill.resumeId;
            model.Description = skill.Description;

            this._context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();

            return new OperationDetails() { IsError = false };
        }
    }
}
