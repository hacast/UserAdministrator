using UserAdministrator.Common.DataCollection;
using UserAdministrator.Queries;
using UserAdministrator.Services.Commands;

namespace UserAdministrator.Services.BusinessValidator.Interface
{
    public interface IUserService
    {
        Task<DataCollection<UserDTO>> GetActivesAsync(int page, int take);
        Task<bool> PostUser(CreateUserDTO createUserDTO);
        Task<bool> DeleteUser(DeleteUserDTO deleteUserDTO);
        Task<bool> UpdateUser(UpdateUserDTO updateUserDTO);
    }
}
