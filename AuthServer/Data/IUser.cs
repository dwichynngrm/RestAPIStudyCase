using AuthServer.Dtos;
using AuthServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthServer.Data
{
    public interface IUser
    {
        IEnumerable<UserDto> GetAllUser();
        Task Registration(CreateUserDto user);
        Task AddRole(string rolename);
        IEnumerable<CreateRoleDto> GetRoles();
        Task AddUserToRole(string username, string role);
        Task<List<string>> GetRolesFromUser(string username);
        Task<User> Authenticate(CreateUserDto createuserDto);
    }
}
