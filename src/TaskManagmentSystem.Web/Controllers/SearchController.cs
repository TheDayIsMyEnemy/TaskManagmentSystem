using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Interfaces;
using TaskManagmentSystem.Web.ViewModels.Search;

namespace TaskManagmentSystem.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITaskService taskService;

        public SearchController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public async Task<IActionResult> Index(SearchViewModel search)
        {
            search.Tasks = await taskService.SearchAsync(1, Constants.TasksPerPage, search.Query, search.Title, search.Description, search.TaskPriority, search.TaskState, null, null, null);
            return View(search);
        }
    }
}
