using Application.Exceptions.Shared;
using Application.Exceptions.User;
using Core.Interfaces;
using MesaApp.Application.UseCases.UserService.CreateUser;

namespace Application.UseCases.UserService.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository)
{
    public async Task Handle(int id)
    {
        if (id == 0) throw new InvalidAttributeException(nameof(id));
        var user = await userRepository.GetByIdAsync(id);
        if (user == null) throw new UserNotFoundException(id);

        await userRepository.DeleteAsync(id);
    }
}