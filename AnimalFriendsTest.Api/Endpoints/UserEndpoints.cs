using Microsoft.EntityFrameworkCore;
using AnimalFriendsTest.Domain.Models.User;

namespace AnimalFriendsTest.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {

        routes.MapPost("/api/User/", async (User user, UserContext db) =>
        {
            db.User.Add(user);
            await db.SaveChangesAsync();
            return Results.Created($"/Users/{user.Id}", user);
        })
        .WithName("CreateUser")
        .Produces<User>(StatusCodes.Status201Created);

        routes.MapDelete("/api/User/{id}", async (int Id, UserContext db) =>
        {
            if (await db.User.FindAsync(Id) is User user)
            {
                db.User.Remove(user);
                await db.SaveChangesAsync();
                return Results.Ok(user);
            }

            return Results.NotFound();
        })
        .WithName("DeleteUser")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
