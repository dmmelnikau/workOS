using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workOS.DataAccessLayer;
using workOS.Model;

namespace workOS.Controllers
{
    public class TaskController : Controller
    {
            TaskLayer objtasks = new TaskLayer();

            [HttpGet]
            [Route("api/Task/Index")]
            public IEnumerable<Tasks> Index()
            {
                return objtasks.GetAllTasks();
            }

            [HttpPost]
            [Route("api/Task/Create")]
            public int Create([FromBody] Tasks tasks)
            {
                return objtasks.AddTask(tasks);
            }

            [HttpGet]
            [Route("api/Task/Details/{id}")]
            public Tasks Details(int id)
            {
                return objtasks.GetTaskData(id);
            }

            [HttpPut]
            [Route("api/Task/Edit")]
            public int Edit([FromBody] Tasks tasks)
            {
                return objtasks.EditTask(tasks);
            }

            [HttpDelete]
            [Route("api/Task/Delete")]
            public int Delete(Tasks tasks)
            {
                return objtasks.DeleteTask(tasks);
            }
        }
}
