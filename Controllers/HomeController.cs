using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskFlowWeb.Data;
using TaskFlowWeb.Models;

// Alias para evitar conflicto con System.Threading.Tasks.TaskStatus
using TaskStatusEnum = TaskFlowWeb.Models.TaskStatus;

namespace TaskFlowWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
{
    var dashboard = new TaskFlowWeb.Models.ViewModels.DashboardViewModel
    {
        TotalProjects = _context.Projects.Count(),
        TotalTasks = _context.Tasks.Count(),

        PendingTasks = _context.Tasks.Count(t => t.Status == TaskStatusEnum.Pendiente),
        InProgressTasks = _context.Tasks.Count(t => t.Status == TaskStatusEnum.EnProgreso),
        CompletedTasks = _context.Tasks.Count(t => t.Status == TaskStatusEnum.Completada),

        OverdueTasks = _context.Tasks.Count(t =>
            t.DueDate != null &&
            t.DueDate < DateTime.Today &&
            t.Status != TaskStatusEnum.Completada)
    };

    return View(dashboard);
}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}