using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public static class BllConfiguration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<SkillRepository>();
            serviceCollection.AddTransient<ResumeRepository>();
            serviceCollection.AddTransient<EducationRepository>();
            serviceCollection.AddTransient<ExperienceRepository>();
            serviceCollection.AddTransient<SpecialityRepository>();
        }
    }
}
