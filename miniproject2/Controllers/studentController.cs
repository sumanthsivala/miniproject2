using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniproject2.Models;
using miniproject2.Models.Domain;
using miniproject2.studentdata;

namespace miniproject2.Controllers
{
    public class studentController : Controller
	{
        private readonly studentcontext mvcstudentcontext;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var student = await mvcstudentcontext.students.ToListAsync();
            return View(student);
        }
        public studentController(studentcontext mvcstudentcontext)
        {
            this.mvcstudentcontext=mvcstudentcontext;
        }

        [HttpGet]
		public IActionResult Add()
		{
			return View();
		}
        [HttpPost]

        public async Task<IActionResult> Add(addstudentviewmodel addstudentRequest)
        {
            var students = new student()
            {
                Id= Guid.NewGuid(),
                Name=addstudentRequest.Name,
                Email=addstudentRequest.Email,
                course=addstudentRequest.course,
                percentage=addstudentRequest.percentage
            };
            await mvcstudentcontext.students.AddAsync(students);
            await mvcstudentcontext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        public async Task<IActionResult> view(Guid id)
        {
             var student=await mvcstudentcontext.students.FirstOrDefaultAsync(x => x.Id==id);
            if (student !=null)
            {
                var viewmodel = new updatestudentview_model()
                {
                    Id= student.Id,
                    Name=student.Name,
                    Email=student.Email,
                    course=student.course,
                    percentage=student.percentage

                };
                return View(viewmodel);
            }
            

			return RedirectToAction("Index");
        }
    }
}

