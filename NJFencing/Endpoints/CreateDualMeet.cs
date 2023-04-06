using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NJFencing.Database;
using NJFencing.Models;
using NJFencing.Utilities;

namespace NJFencing.Endpoints.CreateDualMeet;

using Response = DualMeet;

public class Request
{
    public bool Conference { get; set; }
    public DateTime Date { get; set; }
    public string Team1 { get; set; }
    public string Team2 { get; set; }
    public int? Team1Score1 { get; set; }
    public int? Team1Score2 { get; set; }
    public int? Team1Score3 { get; set; }
    public int? Team2Score1 { get; set; }
    public int? Team2Score2 { get; set; }
    public int? Team2Score3 { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(it => it.Team1).NotEmpty();
        RuleFor(it => it.Team2).NotEmpty();
        RuleFor(it => it.Date).NotEmpty();
        RuleFor(it => it.Conference).NotEmpty();
    }
}

public class Endpoint : Endpoint<Request, Response>
{
    public DatabaseContext Db { get; set; }
    
    public override void Configure()
    {
        Post("dualMeet");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        if (!Db.Teams.Any(l => l.Id == request.Team1)
            || !Db.Teams.Any(l => l.Id == request.Team2))
        {
            await SendErrorsAsync(cancellation: ct);
            return;
        }
        
        var newDual = new DualMeet()
        {
            Id = Nanoid.Nanoid.Generate(),
            Conference = request.Conference,
            Date = request.Date,
            Team1Id = request.Team1,
            Team2Id = request.Team2,
            Records = new List<FencerRecord>(),
        };

        if (request.Team1Score1 != null) newDual.Team1Score1 = (sbyte)request.Team1Score1;
        if (request.Team1Score2 != null) newDual.Team1Score2 = (sbyte)request.Team1Score2;
        if (request.Team1Score3 != null) newDual.Team1Score3 = (sbyte)request.Team1Score3;
        if (request.Team2Score1 != null) newDual.Team2Score1 = (sbyte)request.Team2Score1;
        if (request.Team2Score2 != null) newDual.Team2Score2 = (sbyte)request.Team2Score2;
        if (request.Team2Score3 != null) newDual.Team2Score3 = (sbyte)request.Team2Score3;
        
        var team = Db.DualMeets.Add(newDual);
        Db.SaveChanges();

        await SendAsync(newDual, cancellation: ct);
    }
}