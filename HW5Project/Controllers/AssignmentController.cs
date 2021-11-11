using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW5Project.Models;

namespace HW5Project.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentsDbContext db;

        public AssignmentController(AssignmentsDbContext context)
        {
            this.db = context;
            Debug.WriteLine(db.Assignments.FirstOrDefault());
        }

        [HttpGet]
        public IActionResult AddAssignment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAssignment(Assignments assignment)
        {
            Debug.WriteLine(assignment);
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("CurrentAssignments");
            }

            return View("AddAssignment",assignment);
        }


        [HttpGet]
        public IActionResult CurrentAssignments(string sortOrder)
        {
            IEnumerable<Assignments> all;
            switch (sortOrder)
            {
                case "priority":
                    all = db.Assignments.OrderBy(s => s.Priority).ToList();
                    break;
                case "due_date":
                    all = db.Assignments.OrderBy(s => s.DueDate).ToList();
                    break;
                default:
                    all = db.Assignments.OrderBy(s => s.Priority).ToList();
                    break;
            }
            return View(all);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}