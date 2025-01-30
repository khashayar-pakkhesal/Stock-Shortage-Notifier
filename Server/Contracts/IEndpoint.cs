namespace Server.Contracts;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}