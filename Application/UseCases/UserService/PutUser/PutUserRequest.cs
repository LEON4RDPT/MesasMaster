﻿namespace Application.UseCases.UserService.PutUser;

public class PutUserRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; set; }
}