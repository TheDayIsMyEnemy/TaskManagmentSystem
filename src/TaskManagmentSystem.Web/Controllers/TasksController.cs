using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Entities;
using TaskManagmentSystem.Web.Models;

namespace TaskManagmentSystem.Web.Controllers
{
    public class TasksController : Controller
    {
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

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
