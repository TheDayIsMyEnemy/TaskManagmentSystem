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
using TaskManagmentSystem.Web.ViewModels;
using static TaskManagmentSystem.Web.Constants;

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

        public async Task<IActionResult> Search(SearchInfoViewModel searchInfo)
        {
            return PartialView("_TaskListPartial", await taskService.List(1, 6));
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int taskCount = await taskService.GetTaskCountAsync();
            int totalPages = (int)Math.Ceiling((decimal)taskCount / TasksPageSize);
            page = page < 1 ? 1 : page > totalPages ? totalPages : page;

            var paginationInfo = new PaginationInfoViewModel
            {
                ItemsPerPage = TasksPageSize,
                CurrentPage = page,
                TotalItems = taskCount
            };

            var result = new TasksIndexViewModel
            {
                Tasks = await taskService.List(page, TasksPageSize),
                PaginationInfo = paginationInfo
            };

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskDto task = await taskService.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
                // return Error View
            }
            var model = new TaskDetailsViewModel
            {
                Task = task
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return PartialView("_TaskCreatePartial");
            //return View();
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
