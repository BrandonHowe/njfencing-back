using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NJFencing.Models;

public class Roster
{
    [Key] public string Id { get; set; }
    public string TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }

    public int Season { get; set; }
    public List<Fencer> Fencers { get; set; }
}