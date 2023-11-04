using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> OnPost([FromBody] CreateTaskRecord createTask)
        {
            try 
            {
                taskModel = mapper.Map<TaskModel>(createTask);
                db.TaskEntity.Add(taskModel);
            } 
            catch(AutoMapperMappingException exception)
            {
                return BadRequest($"Infelizmente ocorreu um erro ao gravar uma tarefa: {exception.Message}");
            }
            finally
            {
                await db.SaveChangesAsync();
            }
            return Ok($"A tarefa: {taskModel.Title} foi adicionada com sucesso!");
        }
    }
}