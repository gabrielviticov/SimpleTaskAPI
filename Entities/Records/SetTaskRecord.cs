using System.ComponentModel.DataAnnotations;
using SimpleTaskAPI.Entities.Enums;

namespace SimpleTaskAPI.Entities.Records
{
    public record class SetTaskRecord
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        [EnumDataType(typeof(PriorityEnum))]
        public string Priority { get; private set; } = string.Empty;
        public DateTime LastUpdatedAt { get; private set; } = DateTime.Now;
        [Required]
        public bool IsDone { get; set; } = false;
    }
}