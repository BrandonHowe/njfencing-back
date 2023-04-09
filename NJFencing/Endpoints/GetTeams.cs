using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NJFencing.Database;
using NJFencing.Models;

namespace NJFencing.Endpoints.GetTeams;

using Response = List<Team>;

public class Endpoint : EndpointWithoutRequest<Response>
{
    public DatabaseContext Db { get; set; }
    
    public override void Configure()
    {
        Get("team");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var teams = await Db.Teams
            .OrderBy(l => l.Name)
            .ToListAsync(ct);

        await SendAsync(teams, cancellation: ct);
    }
}