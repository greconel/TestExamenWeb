using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestExamenWeb.Models;

namespace TestExamenWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IAdminRepository<Project> _projectRepository;

        public ProjectsController(IAdminRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            
            return View(await _projectRepository.GetListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectRepository.GetAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,StudentId,SubmissionDate,TheoryScore,PracticalScore,PresentationScore,TotalGrade")] Project project)
        {
            if (ModelState.IsValid)
            {
                
                await _projectRepository.AddAsync(project);
                return RedirectToAction(nameof(Index));
            }
            
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectRepository.GetAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }
            var projects = await _projectRepository.GetListAsync();
            ViewData["StudentId"] = new SelectList(projects, "StudentId", "StudentName", project.StudentId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,StudentId,SubmissionDate,TheoryScore,PracticalScore,PresentationScore,TotalGrade")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpStatusCode statusCode = await _projectRepository.UpdateAsync(id, project);

                if (statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
                else if (statusCode == HttpStatusCode.Conflict)
                {
                    ModelState.AddModelError("", "Unable to update - this product was modified by another user. Click Back to List and try to update again.");
                    ViewData["StudentId"] = new SelectList(await _projectRepository.GetListAsync(), "StudentId", "StudentName", project.StudentId);
                    return View(project);
                }
                return RedirectToAction(nameof(Index));
            }
            var projects = await _projectRepository.GetListAsync();
            ViewData["StudentId"] = new SelectList(projects, "StudentId", "StudentName", project.StudentId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectRepository.GetAsync(id.Value);
               
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            

            await _projectRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
