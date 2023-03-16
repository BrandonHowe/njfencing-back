using System.ComponentModel.DataAnnotations;

namespace NJFencing.Models;

public class Fencer
{
    [Key] public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GradYear { get; set; }
    
    public List<FencerRecord> Records { get; set; }
}