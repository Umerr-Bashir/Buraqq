using Buraqq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Buraqq.Models.ViewModel;


namespace Buraqq.Controllers
{
    public class AdminController : Controller
    {
        private readonly BuraqqContext _context;

        public AdminController(BuraqqContext context)
        {
            _context = context;
        }

        [AuthorizeAdmin]
        public async Task <IActionResult> Index()
        {
            return View(await _context.TeacherDetails.Include(model => model.Teacher).Select(x=> new TeacherInfoViewModel {Id=x.Id,Image=x.Image,Fee=x.Fee,Name=$"{x.Teacher.FirstName} {x.Teacher.LastName}",Subject= _context.TeacherSubjects.Include(y=>y.Subject).Where(y=>y.TeacherId==x.TeacherId).Select(y=>y.Subject.Name).ToList() }).ToListAsync()); ;
        }
    }
}
