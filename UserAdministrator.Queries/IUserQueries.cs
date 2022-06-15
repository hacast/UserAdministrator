using UserAdministrator.Common.DataCollection;
using UserAdministrator.Queries;

namespace UserAdministrator.Services.Queries
{
    public interface IUserQueries
    {
        Task<DataCollection<UserDTO>> GetActivesAsync(int page, int take);
    }
}
