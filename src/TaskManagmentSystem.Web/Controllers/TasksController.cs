using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Entities;
using TaskManagmentSystem.Core.Interfaces;
using TaskManagmentSystem.Core.Services;
using TaskManagmentSystem.Web.Filters;
using TaskManagmentSystem.Web.Models;
using TaskManagmentSystem.Web.ViewModels.Tasks;
using TaskManagmentSystem.Core.DTOs;


namespace TaskManagmentSystem.Web.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
            var list = new List<AppTask>();

            for (int i = 1; i <= 3; i++)
            {
                list.Add(new AppTask { Id = i, Title = $"App Task {i}", Status = (Core.Entities.TaskStatus)i
                    , Priority = (TaskPriority)i});
            }
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskDto task = await taskService.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
                // return Error View
            }

            return View(task);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create(TaskCreateViewModel model)
        {
            int taskId = await taskService
                .CreateTaskAsync(model.Title, model.Description, model.Status, model.Priority, model.DueDate);

            return RedirectToAction(nameof(Details), new { id = taskId });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
