using System.ComponentModel.DataAnnotations;
using NJFencing.Utilities;

namespace NJFencing.Models;

public class FencerRecord
{
    [Key] public string Id { get; set; }
    
    public string FencerId { get; set; }
    public Fencer Fencer { get; set; }
    
    public string MeetId { get; set; }
    public DualMeet Meet { get; set; }
    
    public sbyte Wins { get; set; }
    public sbyte Losses { get; set; }
    public Weapon Weapon { get; set; }
}