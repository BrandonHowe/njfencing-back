using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NJFencing.Database;
using NJFencing.Models;
using NJFencing.Utilities;

namespace NJFencing.Endpoints.CreateTeam;

using Response = Team;

public class Request
{
    public string? Abbreviation { get; set; }
    public string? Coach { get; set; }
    public Conference? Conference { get; set; }
    public string? Icon { get; set; }
    public string Name { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(it => it.Name)
            .NotEmpty();
    }
}

public class Endpoint : Endpoint<Request, Response>
{
    public DatabaseContext Db { get; set; }
    
    public override void Configure()
    {
        Post("team");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        var newTeam = new Team()
        {
            Id = Nanoid.Nanoid.Generate(),
            Name = request.Name
        };
        if (request.Abbreviation != null) newTeam.Abbreviation = request.Abbreviation;
        if (request.Coach != null) newTeam.Coach = request.Coach;
        if (request.Conference != null) newTeam.Conference = request.Conference.Value;
        if (request.Icon != null) newTeam.Icon = request.Icon;
        
        var team = Db.Teams.Add(newTeam);
        Db.SaveChanges();

        await SendAsync(newTeam, cancellation: ct);
    }
}