using Microsoft.EntityFrameworkCore;
using AnimalFriendsTest.Domain.Models.User;
using AnimalFriendsTest.Api.Data;
using AnimalFriendsTest.Domain.Repository;
using AnimalFriendsTest.Domain.Interfaces.Repository;
using AnimalFriendsTest.Domain.Interfaces.Context;
using AnimalFriendsTest.Core.Services;
using AnimalFriendsTest.Core.Interfaces;

namespace AnimalFriendsTest.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {

        routes.MapPost("/api/User/", async (User user, UserContext db) =>
        {

            IUserService userService = new UserService(new UserRepository(db));

			//TODO - Would like to use a Record as DTO, and map using AutoMapper
			//TODO - we want to do some early validation here

			try
			{
				var id = userService.AddUser(user);

				return Results.Json(id);
			}
			catch (Exception ex)
			{
				return Results.Problem(ex.Message);
			}

		})
        .WithName("CreateUser")
        .Produces<User>(StatusCodes.Status201Created);

    }
}
