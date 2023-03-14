using System.ComponentModel.DataAnnotations;

namespace NJFencing.Models;

public class Account
{
    [Key]
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Email { get; set; }
}