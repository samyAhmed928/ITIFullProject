using ITIFullProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIFullProject.Controllers
{
	public class InstructorController : Controller
	{
		private readonly AppDbContext _context;
        public InstructorController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
		{
			var Instructor = _context.Instructors.Include(i=>i.Account).Include(i=>i.Department).ToList();
			return View(Instructor);
		}
		public IActionResult Details()
		{
			string name =HttpContext.Session.GetString("User").ToString();
			return Content(name);

			
		}
	}
}
