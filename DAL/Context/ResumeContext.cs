using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ResumeContext : IdentityDbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
            Database.EnsureCreated();


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Skill>().HasOne<Resume>(s => s.Resume).WithMany(r => r.Skills).HasForeignKey(x => x.resumeId);
            modelBuilder.Entity<Resume>().HasOne<User>(r => r.User).WithOne(u => u.Resume).HasPrincipalKey<Resume>(r => r.userId);

            modelBuilder.Entity<Resume>().Property(r => r.About).IsRequired(false);
            modelBuilder.Entity<Resume>().Property(r => r.LinkOnRep).IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.resumeId).IsRequired(false);

            modelBuilder.Entity<Speciality>().HasOne<Resume>(m => m.Resume).WithMany(r => r.Specialities).HasForeignKey(m => m.resumeId);
            modelBuilder.Entity<Experience>().HasOne<Resume>(e => e.Resume).WithMany(r => r.Experiences).HasForeignKey(e => e.resumeId);
            modelBuilder.Entity<Education>().HasOne<Resume>(e => e.Resume).WithMany(r => r.Educations).HasForeignKey(e => e.resumeId);
        }

        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
    }
}
