using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NJFencing.Database;
using NJFencing.Models;

namespace NJFencing.Endpoints.GetDualMeets;

using Response = List<DualMeet>;

public class Endpoint : EndpointWithoutRequest<Response>
{
    public DatabaseContext Db { get; set; }
    
    public override void Configure()
    {
        Get("dualMeet");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var meets = await Db.DualMeets
            .Include(l => l.Team1)
            .Include(l => l.Team2)
            .ToListAsync(ct);

        await SendAsync(meets, cancellation: ct);
    }
}