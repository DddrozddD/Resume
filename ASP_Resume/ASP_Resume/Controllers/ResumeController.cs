using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ASP_Resume.Controllers
{
    [Authorize]
    public class ResumeController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly ResumeService _resumeService;
        private readonly SkillService _skillService;
        private readonly EducationService _educationService;
        private readonly ExperienceService _experienceService;
        private readonly SpecialityService _specialityService;
        public ResumeController(UserManager<User> userManager, ResumeService resumeService, SkillService skillService,
            EducationService educationService, ExperienceService experienceService, SpecialityService specialityService)

        {
            _userManager = userManager;
            _resumeService = resumeService;
            _skillService = skillService;
            _educationService= educationService;
            _experienceService= experienceService;
            _specialityService= specialityService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            if (resume == null)
            {
                await _resumeService.CreateAsync(new Resume { userId = user.Id, Specialities = new List<Speciality>() });

            }

            user.Resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id);
            user.Resume.Skills = await _skillService.FindByConditionAsync(s => s.resumeId == user.Resume.Id); ;
            user.Resume.Specialities = await _specialityService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            user.Resume.Educations = await _educationService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            user.Resume.Experiences = await _experienceService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            if (user.Resume.Specialities.Count() == 0 || user.Resume.Educations.Count() == 0 || user.Resume.Experiences.Count() == 0 || user.Resume.Skills.Count() == 0)
            {
                return RedirectToAction("AllResumes", "Resume");
            }
            return View(user);
        }
        [AllowAnonymous]
        public async Task<IActionResult> SeeUserResume(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            if (resume == null)
            {
                await _resumeService.CreateAsync(new Resume { userId = user.Id, Specialities = new List<Speciality>() });

            }

            user.Resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id);
            user.Resume.Skills = await _skillService.FindByConditionAsync(s => s.resumeId == user.Resume.Id); ;
            user.Resume.Specialities = await _specialityService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            user.Resume.Educations = await _educationService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            user.Resume.Experiences = await _experienceService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            if (user.Resume.Specialities.Count() == 0 || user.Resume.Educations.Count() == 0 || user.Resume.Experiences.Count() == 0 || user.Resume.Skills.Count() == 0)
            {
                return RedirectToAction("AllResumes", "Resume");
            }
            ViewBag.IsMyResume = false;
            return View("Index", user);
        }
        [AllowAnonymous]
        public async Task<IActionResult> AllResumes()
        {
           var users = new List<User>();
            foreach(var user in _userManager.Users.ToList())
            {
                var resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id);
                if (resume != null)
                {
                    user.Resume = resume;
                    user.Resume.Specialities = await _specialityService.FindByConditionAsync(s => s.resumeId == resume.Id);
                    users.Add(user);
                }
               
            }
            return View(users);
        }

        public async Task<IActionResult> AddSkill(Skill skill)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            skill.Resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            _skillService.CreateAsync(skill);
            return RedirectToAction("CreateResume");
        }

        public async Task<IActionResult> AddEducation(Education education)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            education.Resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            _educationService.CreateAsync(education);
            return RedirectToAction("CreateResume");
        }

        public async Task<IActionResult> AddExperience(Experience experience)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            experience.Resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            _experienceService.CreateAsync(experience);
            return RedirectToAction("CreateResume");
        }

        public async Task<IActionResult> AddSpeciaility(Speciality speciality)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            speciality.Resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            _specialityService.CreateAsync(speciality);
            return RedirectToAction("CreateResume");
        }

        public async Task<IActionResult> FinishResume(string LinkOnRep)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var _resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            _resume.LinkOnRep = LinkOnRep;

            _resumeService.EditAsync(_resume.Id, _resume);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SaveAbout(string About)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var _resume = await _resumeService.FindByConditionItemAsync(r => r.userId == user.Id).ConfigureAwait(false);
            _resume.About = About;

            _resumeService.EditAsync(_resume.Id, _resume);
            return RedirectToAction("CreateResume");
        }
            public async Task<IActionResult> CreateResume()
        {
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var resume  = await _resumeService.FindByConditionItemAsync(r=>r.userId == user.Id).ConfigureAwait(false);
            if (resume == null)
            {
                await _resumeService.CreateAsync(new Resume { userId = user.Id, Specialities = new List<Speciality>()});
               
            }
            
            user.Resume = (await _resumeService.FindByConditionAsync(r => r.userId == user.Id)).First();
            var skills = await _skillService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            user.Resume.Skills = skills;
            user.Resume.Specialities = await _specialityService.FindByConditionAsync(s=>s.resumeId== user.Resume.Id);
            user.Resume.Educations = await _educationService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            user.Resume.Experiences= await _experienceService.FindByConditionAsync(s => s.resumeId == user.Resume.Id);
            return View(user);
        }
    }
}
