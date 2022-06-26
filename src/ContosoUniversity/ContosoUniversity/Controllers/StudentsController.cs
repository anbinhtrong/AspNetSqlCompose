using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;
        private readonly ILogger _logger;


        public StudentsController(SchoolContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var conn = _context.Database.GetDbConnection().ConnectionString;
            _logger.LogInformation(conn);
            try
            {
                DbInitializer.Initialize(_context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
            }
            return View(await _context.Students.ToListAsync());
        }
    }
}
