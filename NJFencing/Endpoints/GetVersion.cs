using FastEndpoints;

namespace NJFencing.Endpoints.GetVersion;

public record Response(string Version);

public class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("version");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new Response("v0.0.1"), cancellation: ct);
    }
}