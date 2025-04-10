
namespace Application.UseCases.UserService.GetAllUsers
{
    public class GetAllUsersResponse
    {
        public List<UserDTO> Users { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public bool IsAdmin { get; set; }
 
    }
}
