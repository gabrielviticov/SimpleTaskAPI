using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleTaskAPI.Entities.Enums;

namespace SimpleTaskAPI.Entities.Models;
[Table("TB_TASK")]
public class TaskModel
{
    [Key]
    [Required]
    [Column("CL_PK_IDENTIFY")]
    public Guid Identify { get; set; }
    [Required]
    [StringLength(255)]
    [Column("CL_TITLE")]
    public string Title { get; set; } = string.Empty;
    [Column("CL_DESCRIPTION")]
    public string Description { get; set; } = string.Empty;
    [Column("CL_PRIORITY")]
    [EnumDataType(typeof(PriorityEnum))]
    public string Priority { get; set; } = "NENHUMA_PRIORIDADE";
    [Column("CL_CREATED_AT")]
    public DateTime CreatedAt { get; private set; } = DateTime.Now.Date;
    [Column("CL_LAST_UPDATED_AT")]
    public DateTime LastUpdatedAt { get; private set; } = DateTime.Now.Date;
    [Column("CL_IS_DONE")]
    public bool IsDone { get; set; } = false;
}
