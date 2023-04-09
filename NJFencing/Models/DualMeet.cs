using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NJFencing.Models;

public class DualMeet
{
    [Key] public string Id { get; set; }
    public bool Conference { get; set; }
    public DateTime Date { get; set; }
    public string Team1Id { get; set; }
    [ForeignKey("Team1Id")]
    public Team Team1 { get; set; }
    [DefaultValue(0)]
    public sbyte Team1Score1 { get; set; }
    [DefaultValue(0)]
    public sbyte Team1Score2 { get; set; }
    [DefaultValue(0)]
    public sbyte Team1Score3 { get; set; }
    [DefaultValue(0)]
    public sbyte Team1Score { get; set; }
    public string Team2Id { get; set; }
    [ForeignKey("Team2Id")]
    public Team Team2 { get; set; }
    [DefaultValue(0)]
    public sbyte Team2Score1 { get; set; }
    [DefaultValue(0)]
    public sbyte Team2Score2 { get; set; }
    [DefaultValue(0)]
    public sbyte Team2Score3 { get; set; }
    [DefaultValue(0)]
    public sbyte Team2Score { get; set; }
    [InverseProperty("Meet")]
    public List<FencerRecord> Records { get; set; }
}