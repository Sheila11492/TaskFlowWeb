using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskFlowWeb.Models
{
   public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Inicializamos la lista para que nunca sea null
    public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
} 
}