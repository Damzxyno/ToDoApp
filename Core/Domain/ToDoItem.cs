using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain;

public class ToDoItem : BaseEntity
{
    public string Narration { get; set; }
    public bool IsCompleted { get; set; }

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

}
