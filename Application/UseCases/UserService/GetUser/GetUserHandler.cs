using Application.Exceptions.User;
using Core.Interfaces;

namespace Application.UseCases.UserService.GetUser;

public class GetUserHandler(IUserRepository userRepository)
{
    public async Task<GetUserResponse> Handle(GetUserRequest request)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null) throw new UserNotFoundException(request.Id);
        return new GetUserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsAdmin = user.IsAdmin
        };
    }
}