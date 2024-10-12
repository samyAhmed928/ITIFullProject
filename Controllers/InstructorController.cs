using ITIFullProject.Data;
using ITIFullProject.Models;
using ITIFullProject.ViewModels;
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
		[HttpGet]
		public IActionResult Createnew()
		{
            InstructorVM instructorVM = new InstructorVM();
			instructorVM.CoursesList=_context.Courses.ToList();
			instructorVM.DeptList=_context.Departments.ToList();
            return View(instructorVM);
		}
        public IActionResult SaveNew(InstructorVM instructorVM)
        {
            // Check if account exists or the instructor's name is null
            var account = _context.Accounts.FirstOrDefault(a => a.UserName == instructorVM.AccountName);

            if (!string.IsNullOrEmpty(instructorVM.Name) && account == null)
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    // Create new instructor
                    Instructor instructor = new Instructor
                    {
                        Name = instructorVM.Name,
                        Address = instructorVM.Address,
                        Image = instructorVM.Image,
                        DeptId = instructorVM.DeptId,
                        CoursesInstructors = new List<CourseInstructor>() // Initialize the relationship
                    };

                    // Add instructor to database
                    _context.Instructors.Add(instructor);
                    _context.SaveChanges();

                    // Create new account for the instructor
                    Account acc = new Account
                    {
                        UserName = instructorVM.AccountName,
                        InstructorId = instructor.Id
                    };

                    _context.Accounts.Add(acc);
                    instructor.Account = acc; // Establish relationship with the account

                    // Add selected courses to the instructor
                    foreach (var courseId in instructorVM.coursesid)
                    {
                        instructor.CoursesInstructors.Add(new CourseInstructor
                        {
                            CourseId = courseId,
                            InstructorId = instructor.Id
                        });
                    }

                    _context.SaveChanges();
                    transaction.Commit(); // Commit the transaction

                    return RedirectToAction("Index");
                }
                catch
                {
                    transaction.Rollback(); // Rollback in case of an error
                    ModelState.AddModelError("", "An error occurred while saving the instructor.");
                }
            }

            // If validation fails or account already exists
            ModelState.AddModelError("", "Account already exists or instructor name is invalid.");
            return View("Createnew", instructorVM);
        }
    }
}
