using System.Text.Json;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NJFencing.Database;
using NJFencing.Models;

namespace NJFencing.Endpoints.GetFencer;

using Response = Fencer;

public class Request
{
    public string Id { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(it => it.Id)
            .NotEmpty();
    }
}

public class Endpoint : Endpoint<Request, Response>
{
    public DatabaseContext Db { get; set; }
    
    public override void Configure()
    {
        Get("fencer/{Id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        var acc = await Db.Fencers
            .Where(l => l.Id == request.Id)
            .Include(l => l.Records).ThenInclude(l => l.Meet).ThenInclude(l => l.Team1)
            .Include(l => l.Records).ThenInclude(l => l.Meet).ThenInclude(l => l.Team2)
            .Include(l => l.Team)
            .FirstOrDefaultAsync(ct);
        
        if (acc == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await SendAsync(acc, cancellation: ct);
    }
}