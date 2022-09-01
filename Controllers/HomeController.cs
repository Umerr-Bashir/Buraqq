using Buraqq.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Buraqq.Models.ViewModel;

namespace Buraqq.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly BuraqqContext _context;

        public HomeController(BuraqqContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() //List of Teacher Profile
        {
            return View(await _context.TeacherDetails.Include(model => model.Teacher).Select(x => new TeacherInfoViewModel { Id = x.Id, Image = x.Image, Fee = x.Fee, Name = $"{x.Teacher.FirstName} {x.Teacher.LastName}", Subject = _context.TeacherSubjects.Include(y => y.Subject).Where(y => y.TeacherId == x.TeacherId).Select(y => y.Subject.Name).ToList() }).ToListAsync()); ;
        }
        public async Task<IActionResult> TeacherProfile(int id) //Teacher Profile
        {
            return View(await _context.TeacherDetails.Where(y => y.Id == id).Include(model => model.Teacher).Select(x => new TeacherInfoViewModel { Id = x.Id,Email=x.Teacher.Email,Description=x.Description, Image = x.Image, Fee = x.Fee, Name = $"{x.Teacher.FirstName} {x.Teacher.LastName}", Subject = _context.TeacherSubjects.Include(y => y.Subject).Where(y => y.TeacherId == x.TeacherId).Select(y => y.Subject.Name).ToList() }).ToListAsync()); ;
        }
        public async Task<IActionResult> Message(int id)
        {
            return View(await _context.TeacherDetails.Where(y => y.Id == id).Include(model => model.Teacher).Select(x => new TeacherInfoViewModel { Id = x.Id,Image = x.Image}).FirstOrDefaultAsync()); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}