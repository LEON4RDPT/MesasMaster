﻿namespace Application.UseCases.UserService.CreateUser;

public class CreateUserRequest
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}