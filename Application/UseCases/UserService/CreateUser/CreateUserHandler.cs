using Application.Exceptions.Shared;
using Application.Exceptions.User;
using Application.Helpers;
using Core.Entities;
using Core.Interfaces;
using MesaApp.Application.UseCases.UserService.CreateUser;

namespace Application.UseCases.UserService.CreateUser;

public class CreateUserHandler(IUserRepository userRepository)
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request)
    {
        if (string.IsNullOrEmpty(request.Name)) throw new MissingAttributeException(nameof(request.Name));

        if (request.Name.Length < 6) throw new InvalidAttributeException(nameof(request.Name));

        if (string.IsNullOrEmpty(request.Email)) throw new MissingAttributeException(nameof(request.Email));

        if (!EmailValidator.IsValidEmail(request.Email)) throw new InvalidAttributeException(nameof(request.Email));

        if (string.IsNullOrEmpty(request.Password)) throw new MissingAttributeException(nameof(request.Password));

        if (request.Name.Length < 6) throw new InvalidAttributeException(nameof(request.Password));

        if (await userRepository.EmailExistsAsync(request.Email)) throw new EmailAlreadyInUseException(request.Email);

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            IsAdmin = false,
            IsActive = true
        };

        await userRepository.AddAsync(user);

        return new CreateUserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password,
            Email = user.Email,
            IsAdmin = user.IsAdmin
        };
    }
}