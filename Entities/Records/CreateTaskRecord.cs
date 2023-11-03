using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleTaskAPI.Entities.Enums;

namespace SimpleTaskAPI.Entities.Records
{
    public record class CreateTaskRecord
    {
        [Required(ErrorMessage = "O preenchimento do campo é obrigatório")]
        [StringLength(255)]
        [DisplayName("Título da tarefa")]
        public string Title { get; set; } = string.Empty;
        [DisplayName("Descrição da tarefa [opcional]")]
        public string Description { get; set; } = string.Empty;
        [EnumDataType(typeof(PriorityEnum))]
        [DisplayName("Prioridade da tarefa [padrão: \"Nenhuma Prioridade\"]")]
        public string Priority { get; set; } = string.Empty;
        [DisplayName("Tarefa criada em")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [DisplayName("Última atualização da tarefa em")]
        public DateTime LastUpdatedAt { get; private set; } = DateTime.Now;
        [DisplayName("A tarefa foi concluída?")]
        public bool IsDone { get; private set; } = false;
    }
}