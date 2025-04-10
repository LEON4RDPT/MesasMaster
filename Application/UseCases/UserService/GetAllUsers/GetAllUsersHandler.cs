
using Core.Interfaces;

namespace Application.UseCases.UserService.GetAllUsers
{
    public class GetAllUsersHandler(IUserRepository userRepository)
    {
        public async Task<IEnumerable<UserDTO>> Handle()
        {
            var users = await userRepository.GetAllAsync();
            
            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.Id, 
                Name = user.Name,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            }).ToList();
            
            return userDTOs;
        }
    }
}
