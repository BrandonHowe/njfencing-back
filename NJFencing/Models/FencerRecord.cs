using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NJFencing.Utilities;

namespace NJFencing.Models;

public class FencerRecord
{
    [Key] public string Id { get; set; }
    
    public string FencerId { get; set; }
    [ForeignKey("FencerId")]
    public Fencer Fencer { get; set; }
    
    public string MeetId { get; set; }
    [ForeignKey("MeetId")]
    public DualMeet Meet { get; set; }
    
    public sbyte Wins { get; set; }
    public sbyte Losses { get; set; }
    public Weapon Weapon { get; set; }
}