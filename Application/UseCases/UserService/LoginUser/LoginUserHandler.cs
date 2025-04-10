using Application.Exceptions.Shared;
using Core.Interfaces;

namespace Application.UseCases.UserService.LoginUser;

public class LoginUserHandler(IUserRepository userRepository)
{
    public async Task<LoginUserResponse> Handle(LoginUserRequest request)
    {
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new MissingAttributeException(nameof(request.Email));
        }

        if (string.IsNullOrEmpty(request.Password))
        {
            throw new MissingAttributeException(nameof(request.Password));
        }

        return new LoginUserResponse()
        {
            Token = await userRepository.Login(request.Email, request.Password)
        };
    }
}