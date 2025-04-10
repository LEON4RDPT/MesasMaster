using Application.Exceptions.User;
using Core.Interfaces;

namespace Application.UseCases.UserService.PutUser;

public class PutUserHandler(IUserRepository userRepository)
{
    public async Task Handle(PutUserRequest request)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null) throw new UserNotFoundException(request.Id);

        if (!string.IsNullOrEmpty(request.Email))
        {
            if (await userRepository.EmailExistsAsync(request.Email))
            {
                throw new EmailAlreadyInUseException(request.Email);
            }
            user.Email = request.Email;
        }
        if (!string.IsNullOrEmpty(request.Name))
        {
            user.Name = request.Name;
        }
        if (!string.IsNullOrEmpty(request.Password))
        {
            user.Password = request.Password;
        }
        if (user.IsAdmin != request.IsAdmin)
        {
            user.IsAdmin = request.IsAdmin;
        }

        await userRepository.UpdateAsync(user);
        
    }
}