using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTaskAPI.Data;
using SimpleTaskAPI.Entities.Models;
using SimpleTaskAPI.Entities.Records;

namespace SimpleTaskAPI.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class TaskController : ControllerBase
    {

        private TaskModel taskModel;
        private ApplicationDbContext db;
        private IMapper mapper;
        public TaskController(TaskModel _taskModel, ApplicationDbContext _db, IMapper _mapper)
        {
            taskModel = _taskModel;
            db = _db;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> OnGetAll([FromQuery] byte skip = 0, [FromQuery] byte take = 5)
        {
            return await db.TaskEntity.Skip(skip).Take(take).ToListAsync();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> OnGetByIdentify([FromQuery] Guid identify)
        {
            var taskFind = await db.TaskEntity.FirstOrDefaultAsync(task => task.Identify == identify);
            if (taskFind is null) return NotFound("A tarefa pesquisada não foi encontrada");
            return Ok(taskFind);
        }
        

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> OnPost([FromBody] CreateTaskRecord createTask)
        {
            try 
            {
                taskModel = mapper.Map<TaskModel>(createTask);
                db.TaskEntity.Add(taskModel);
            } 
            catch(DbException exception)
            {
                return BadRequest($"Infelizmente ocorreu um erro ao gravar uma tarefa: {exception.Message}");
            }
            finally
            {
                await db.SaveChangesAsync();
            }
            return CreatedAtAction(nameof(OnGetByIdentify), new { id = taskModel.Identify}, taskModel );
        }

        [HttpPatch]
        [Route("Set")]
        public async Task<IActionResult> OnSet([FromBody] JsonPatchDocument<UpdateTaskRecord> jsonPatch, [FromQuery] Guid identify)
        {
            var task = db.TaskEntity.FirstOrDefault(task => task.Identify == identify);
            if (taskModel is null) return NotFound("A tarefa pesquisada não foi encontrada");
            
            var task1 = mapper.Map<UpdateTaskRecord>(task);
            jsonPatch.ApplyTo(task1, ModelState);        
            if (!TryValidateModel(task1))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(task1, task);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> OnUpdate([FromBody] UpdateTaskRecord updateTask, [FromQuery] Guid identify)
        {
            var task = db.TaskEntity.FirstOrDefault(task => task.Identify == identify);
            if (task is null) return NotFound("A tarefa não foi encontrada");
            mapper.Map(updateTask, task);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> OnDeleteAll()
        {
            try
            {
                List<TaskModel> tasks = db.TaskEntity.ToList();
                if (tasks.Count > 0)
                {
                    db.TaskEntity.RemoveRange(tasks);
                } 
            }
            catch(DbException exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                await db.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> OnDeleteByIdentify([FromQuery] Guid identify)
        {
            var task = db.TaskEntity.FirstOrDefault(task => task.Identify == identify);
            if (task is null) return NotFound("A tarefa informada não foi encontrada");
            db.TaskEntity.Remove(task);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}