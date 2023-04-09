using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NJFencing.Models;

public class Fencer
{
    [Key] public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GradYear { get; set; }
    public string TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
    [InverseProperty("Fencer")]
    
    public List<FencerRecord> Records { get; set; }
}