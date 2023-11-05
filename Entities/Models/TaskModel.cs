using System.ComponentModel;
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
    [Required(ErrorMessage = "O preenchimento do campo é obrigatório")]
    [StringLength(255)]
    [Column("CL_TITLE")]
    [DisplayName("Título da tarefa")]
    public string Title { get; set; } = string.Empty;
    [Column("CL_DESCRIPTION")]
    [DisplayName("Descrição da tarefa [opcional]")]
    public string Description { get; set; } = string.Empty;
    [Column("CL_PRIORITY")]
    [EnumDataType(typeof(PriorityEnum))]
    [DisplayName("Prioridade da tarefa [padrão: \"Nenhuma Prioridade\"]")]
    public string Priority { get; set; } = "NENHUMA_PRIORIDADE";
    [Column("CL_CREATED_AT")]
    [DisplayName("Tarefa criada em")]
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    [Column("CL_LAST_UPDATED_AT")]
    [DisplayName("Última atualização da tarefa em")]
    public DateTime LastUpdatedAt { get; private set; } = DateTime.Now;
    [Column("CL_IS_DONE")]
    [DisplayName("A tarefa foi concluída?")]
    public bool IsDone { get; set; } = false;

    
}
