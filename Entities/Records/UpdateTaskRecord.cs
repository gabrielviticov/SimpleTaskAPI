using System.ComponentModel.DataAnnotations;
using SimpleTaskAPI.Entities.Enums;

namespace SimpleTaskAPI.Entities.Records
{
    public class UpdateTaskRecord
    {
        [Required(ErrorMessage = "O preenchimento do campo é obrigatório")]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [EnumDataType(typeof(PriorityEnum))]
        public string Priority { get; set; } = string.Empty;
        public DateTime LastUpdatedAt { get; private set; } = DateTime.Now;
        public bool IsDone { get; set; } = false;
    }
}