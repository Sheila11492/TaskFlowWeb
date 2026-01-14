using System;
using System.ComponentModel.DataAnnotations;

namespace TaskFlowWeb.Models
{
    public enum TaskStatus
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public enum TaskPriority
    {
        Baja = 1,
        Media = 2,
        Alta = 3
    }

    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; } = TaskStatus.Pendiente;

        // ✅ Fecha límite obligatoria, no nullable
        [Required(ErrorMessage = "La fecha límite es obligatoria")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(TaskItem), nameof(ValidateDueDate))]
        public DateTime DueDate { get; set; }

        [Required]
        public TaskPriority Priority { get; set; } = TaskPriority.Media;

        [Required(ErrorMessage = "Selecciona un proyecto")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public static ValidationResult? ValidateDueDate(DateTime dueDate, ValidationContext context)
        {
            if (dueDate.Date < DateTime.Today)
                return new ValidationResult("La fecha límite no puede ser anterior a hoy");

            return ValidationResult.Success;
        }
    }
}