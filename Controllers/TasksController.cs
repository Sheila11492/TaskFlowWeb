using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskFlowWeb.Data;
using TaskFlowWeb.Models;

namespace TaskFlowWeb.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index(TaskFlowWeb.Models.TaskStatus? statusFilter)
        {
            var tasks = _context.Tasks.Include(t => t.Project).AsQueryable();

            if (statusFilter != null)
                tasks = tasks.Where(t => t.Status == statusFilter);

            ViewBag.StatusFilter = statusFilter;

            // SelectList con namespace completo para evitar ambigüedad
            ViewBag.StatusList = new SelectList(
                Enum.GetValues(typeof(TaskFlowWeb.Models.TaskStatus)),
                statusFilter
            );

            return View(await tasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var taskItem = await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskItem == null) return NotFound();

            return View(taskItem);
        }

        /// GET: Tasks/Create
public IActionResult Create()
{
    PopulateDropdowns();
    return View();
}

// POST: Tasks/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(TaskItem task)
{
    if (!ModelState.IsValid)
    {
        PopulateDropdowns(task);
        return View(task);
    }

    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

// Método auxiliar para llenar los dropdowns
private void PopulateDropdowns(TaskItem? task = null)
{
    ViewBag.Projects = new SelectList(_context.Projects, "Id", "Name", task?.ProjectId);
    ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(TaskFlowWeb.Models.TaskStatus)));
    ViewBag.PriorityList = new SelectList(Enum.GetValues(typeof(TaskPriority)), task?.Priority);
}

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null) return NotFound();

            ViewBag.Projects = new SelectList(_context.Projects, "Id", "Name", taskItem.ProjectId);
            ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(TaskFlowWeb.Models.TaskStatus)), taskItem.Status);
            ViewBag.PriorityList = new SelectList(Enum.GetValues(typeof(TaskFlowWeb.Models.TaskPriority)), taskItem.Priority);

            return View(taskItem);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                // 🔹 Namespace completo para evitar ambigüedad
                ViewBag.Projects = new SelectList(_context.Projects, "Id", "Name", taskItem.ProjectId);
                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(TaskFlowWeb.Models.TaskStatus)), taskItem.Status);
                ViewBag.PriorityList = new SelectList(Enum.GetValues(typeof(TaskFlowWeb.Models.TaskPriority)), taskItem.Priority);

                return View(taskItem);
            }

            try
            {
                _context.Update(taskItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(taskItem.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var taskItem = await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskItem == null) return NotFound();

            return View(taskItem);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem != null)
            {
                _context.Tasks.Remove(taskItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}