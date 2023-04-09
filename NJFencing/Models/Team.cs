using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NJFencing.Utilities;

namespace NJFencing.Models;

public class Team
{
    [Key] public string Id { get; set; }
    public string Abbreviation { get; set; }
    public string? Coach { get; set; }
    public Conference? Conference { get; set; }
    public Gender Gender { get; set; }
    public string? Icon { get; set; }
    [Required] public string Name { get; set; }
    public string Town { get; set; }
    public string Mascot { get; set; }
    
    [InverseProperty("Team1")]
    public List<DualMeet> HomeMeets { get; set; }
    [InverseProperty("Team2")]
    public List<DualMeet> AwayMeets { get; set; }
}