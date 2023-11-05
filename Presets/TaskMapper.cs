using AutoMapper;
using SimpleTaskAPI.Entities.Models;
using SimpleTaskAPI.Entities.Records;

namespace SimpleTaskAPI.Presets
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<CreateTaskRecord, TaskModel>();
            CreateMap<UpdateTaskRecord, TaskModel>();
            CreateMap<TaskModel, SetTaskRecord>();
            CreateMap<TaskModel, UpdateTaskRecord>();
        }
    }
}