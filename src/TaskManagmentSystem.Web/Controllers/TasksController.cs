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

        private async Task<PaginationViewModel> GetPaginationViewModel(int page)
        {
            int taskCount = await taskService.GetTaskCountAsync();
            int totalPages = (int)Math.Ceiling((decimal)taskCount / TasksPageSize);
            page = page < 1 ? 1 : page > totalPages ? totalPages : page;

            var paginationInfo = new PaginationViewModel
            {
                ItemsPerPage = TasksPageSize,
                CurrentPage = page,
                TotalItems = taskCount
            };

            return paginationInfo;
        }

        public async Task<IActionResult> Search(SearchViewModel search)
        {
            search.Tasks = await taskService.SearchAsync(1, TasksPageSize, search.Q);
            return View(search);
        }

        public async Task<IActionResult> Index(int page = 1)
        {       
            if (page < 1)
            {
                page = 1;
            }

            var result = new TasksIndexViewModel
            {
                Tasks = await taskService.List(page, TasksPageSize),
                Pagination = await GetPaginationViewModel(page)
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
        //[ValidateModel]
        public async Task<IActionResult> Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_TaskCreatePartial", model);
            }

            int taskId = await taskService
                .CreateTaskAsync(model.Title,
                                 model.Description,
                                 model.Status,
                                 model.Priority,
                                 model.DueDate);

            //return RedirectToAction(nameof(Details), new { id = taskId });
            return PartialView("_TaskListPartial", await taskService.List(1, TasksPageSize));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
